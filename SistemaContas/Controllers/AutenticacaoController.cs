using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using SistemaContas.Models;
using SistemaContas.Services;
using System.Diagnostics;
using System.Security.Claims;
using System.Web;

namespace SistemaContas.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly UserService _service;

        public AutenticacaoController(UserService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {

            var result = await _service.GetByEmail(user);

            if (result is not null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, (result.Name ?? "")));
                claims.Add(new Claim(ClaimTypes.Role, result.Id.ToString()));

                var claimsIdentity = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddHours(2),
                    IssuedUtc = DateTime.Now
                };


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);


                return RedirectToAction("Index", "Home");

            }

            ViewBag.FirstNameError = "Email ou senha invalidos";

            return View();
            
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Clear();
            
            return RedirectToAction("Login");
        }
        public IActionResult Password()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            await _service.CreateAsync(user);

            return RedirectToAction(nameof(Login));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}