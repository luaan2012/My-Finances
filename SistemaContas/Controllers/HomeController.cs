using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaContas.Models;
using SistemaContas.Services;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Security.Claims;

namespace SistemaContas.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _service;

        public HomeController(UserService service)
        {
            _service = service;
        }

        [Authorize]
        [Route("Home")]
        public async Task<IActionResult> Index()
        {
            var result = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
            var id = int.Parse(result.Last());
            ViewBag.Name = result.First();
            ViewBag.Id = result.Last();
            ViewBag.User = await _service.GetListUser(id);

            ViewData["Menu"] = result.First();
            ViewData["Id"] = result.Last();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SaveNote(string title, string? id, string content, string titulo, string adicionar)
        {
            try

            {
                if (titulo == "titulo1" || titulo == "anotacao1")
                {
                    if (adicionar == "add")
                    {
                        var note = new Note { Title = title, Content = content, UserId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).Last()) };
                        await _service.SaveNote(note);
                    }
                    else
                    {
                        var note = new Note { Id = int.Parse(id), Title = title, Content = content, UserId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).Last()) };
                        await _service.SaveNote(note);
                    }

                } else if (titulo == "titulo2" || titulo == "anotacao2")
                {
                    if (adicionar == "add")
                    {
                        var note = new Note2 { Title = title, Content = content, UserId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).Last()) };
                        await _service.SaveNote2(note);
                    }
                    else
                    {
                        var note = new Note2 { Id = int.Parse(id), Title = title, Content = content, UserId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).Last()) };
                        await _service.SaveNote2(note);
                    }
                }
                else {
                    if (adicionar == "add")
                    {
                        var note = new Note3 { Title = title, Content = content, UserId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).Last()) };
                        await _service.SaveNote3(note);
                    }
                    else
                    {
                        var note = new Note3 { Id = int.Parse(id), Title = title, Content = content, UserId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).Last()) };
                        await _service.SaveNote3(note);
                    }

                }

            }
            catch (Exception e)
            {

                return Json(new { status = 0, message = "Failed " + e });
            }
            return Json(new { status = 1, message = "Success" });

        }


        [HttpPost]
        public async Task<ActionResult> ExcluirNote(string excluir, string? id)
        {
            if (excluir == null)
            {

                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                if (excluir == "excluir1")
                {
                    var note = new Note { Title = "Titulo", Content = "Escreva algo aqui.." };
                    await _service.DeleteNote(id);
                }
                else if (excluir == "excluir2")
                {
                    var note = new Note2 { Title = "Titulo", Content = "Escreva algo aqui.." };
                    await _service.DeleteNote2(id);
                }
                else
                {
                    var note = new Note3 { Title = "Titulo", Content = "Escreva algo aqui.." };
                    await _service.DeleteNote3(id);
                }

            }
            catch (Exception e)
            {

                return Json(new { status = 0, message = "Failed " + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> SaveRemenber(Remember remember)
        {

            if (remember.Text is null)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.SaveRemember(remember);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> ChangeGoals(Goal goal)
        {

            if (goal.Name is null)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.ChangeGoals(goal);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteRemember(int id)
        {

            if (id < 0)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.DeleteRemember(id);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> DeleteGoal(int id)
        {

            if (id < 0)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.DeleteGoal(id);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> SaveDebts(Debts debts)
        {

            if (debts.Name is null)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.SaveDebts(debts);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> SaveBills(Bills bills)
        {

            if (bills.Name is null)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.SaveBills(bills);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> SaveGoals(Goal goal)
        {

            if (goal.Name is null)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.SaveGoals(goal);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> SaveEarnings(Earning earning)
        {

            if (earning is null)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.SaveEarnings(earning);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> DeleteBills(int id)
        {

            if (id < 0)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.DeleteBills(id);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> DeleteDebts(int id)
        {

            if (id < 0)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.DeleteDebts(id);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> UpdateDebts(Debts debts)
        {

            if (debts.Id < 0)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.UpdateDebts(debts);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> UpdateBills(Bills bills)
        {

            if (bills.Id < 0)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.UpdateBills(bills);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> UpdateTableDebts(Debts debts)
        {

            if (debts.Id < 0)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.UpdateTableDebts(debts);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpPost]
        public async Task<IActionResult> UpdateTableBills(Bills bills)
        {

            if (bills.Id < 0)
            {
                return Json(new { status = 0, message = "Failed" });
            }

            try
            {
                await _service.UpdateTableBills(bills);
            }
            catch (Exception e)
            {
                return Json(new { status = 0, message = "Failed" + e });
            }
            return Json(new { status = 1, message = "Success" });

        }

        [HttpGet]
        public IActionResult Echart(int id)
        {

            var arr = _service.Echart(id);

            return Json(new { Retorno = arr, message = "Success" });

        }

        [HttpGet]
        public IActionResult Chart(int id)
        {

            var arr = _service.Chart(id);

            return Json(new { Retorno = arr, message = "Success" });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}