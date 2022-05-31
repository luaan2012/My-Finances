using Microsoft.EntityFrameworkCore;
using SistemaContas.Data;
using SistemaContas.Models.IService;
using SistemaContas.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SistemaContas.Until;
using System.Globalization;

namespace SistemaContas.Services
{
    public class UserService : IUserService<User>
    {
        private readonly DataContext _db;

        public UserService(DataContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(User obj)
        {
            try
            {
                await _db.User.AddAsync(obj);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task DeleteAsync(int? id)
        {
            try
            {
                var user = await GetAsync(id);
                _db.User.Remove(user);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task DeleteBills(int? id)
        {
            try
            {
                var table = _db.Bills.Find(id);
                if(table is not null)
                {
                    _db.Bills.Remove(table);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task DeleteDebts(int? id)
        {
            try
            {
                var table = _db.Debts.Find(id);
                if(table is not null)
                {
                    _db.Debts.Remove(table);
                    await _db.SaveChangesAsync();
                }


            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task<User> GetAsync(int? id)
        {
            try
            {
                var result = await _db.User.FindAsync(id);
                if (result == null)
                {
                    return null;
                }

                return result;
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task SaveLastLogin(User user)
        {
            try
            {
                _db.Entry(user).Property(x => x.LastDate).IsModified = true;
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception("Error: " + e.Message);
            }
            
        }

        public async Task<User> GetByEmail(User user)
        {
            try
            {
                var result = await _db.User.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefaultAsync();
                if (result is not null)
                {
                    result.LastDate = DateTime.Now;
                    await SaveLastLogin(result);
                    return result;
                }

                return null;
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task UpdateAsync(User obj)
        {
            try
            {
                _db.User.Update(obj);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }
        
        public async Task<IEnumerable<User>> GetListUser(int? id)
        {
            try
            {
                return await _db.User.Where(x => x.Id == id).Include(n => n.Notes).Include(n => n.Notes2).Include(n => n.Notes3).Include(b => b.Bills).Include(d => d.Debts)
                .Include(g => g.Goal).Include(e => e.Earnings).ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
            
        }
        public async Task SaveNote(Note title)
        {
            try
            {
                bool hasAny = await _db.Note.AnyAsync(x => x.Id == title.Id);
                if (!hasAny)
                {
                    await _db.Note.AddAsync(title);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    _db.Note.Update(title);
                    await _db.SaveChangesAsync();
                }
                
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }
        public async Task SaveNote2(Note2 title)
        {
            try
            {

                if (title is not null)
                {
                    bool hasAny = await _db.Note2.AnyAsync(x => x.Id == title.Id);
                    if (!hasAny)
                    {
                        await _db.Note2.AddAsync(title);
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        _db.Note2.Update(title);
                        await _db.SaveChangesAsync();
                    }
                    
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }
        public async Task SaveNote3(Note3 title)
        {
            try
            {
                bool hasAny = await _db.Note3.AnyAsync(x => x.Id == title.Id);
                if (!hasAny)
                {
                    await _db.Note3.AddAsync(title);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    _db.Note3.Update(title);
                    await _db.SaveChangesAsync();
                }
                
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task DeleteNote(string? id)
        {
            try
            {
                if (id is null)
                {
                    return;
                }
                var obj = await _db.Note.FindAsync(int.Parse(id));
                if (obj is not null)
                {
                    _db.Note.Remove(obj);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }

        }
        public async Task DeleteNote2(string? id)
        {
            try
            {
                if (id is null)
                {
                    return;
                }
                var obj = await _db.Note2.FindAsync(int.Parse(id));
                if (obj is not null)
                {
                    _db.Note2.Remove(obj);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e);
            }

        }
        public async Task DeleteNote3(string? id)
        {
            try
            {
                if (id is null)
                {
                    return;
                }
                var obj = await _db.Note3.FindAsync(int.Parse(id));
                if (obj is not null)
                {
                    _db.Note3.Remove(obj);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }

        }

        public async Task SaveDebts(Debts debts)
        {
            try
            {
                if (debts is not null)
                {
                    _db.Debts.Add(debts);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task SaveBills(Bills bills)
        {
            try
            {
                if (bills is not null)
                {
                    _db.Bills.Add(bills);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task SaveGoals(Goal goal)
        {
            try
            {
                if (goal is not null)
                {
                    _db.Goal.Add(goal);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }
        public async Task SaveEarnings(Earning earnings)
        {
            try
            {
                if (earnings is not null)
                {
                    _db.Earning.Add(earnings);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task UpdateBills(Bills bills)
        {
            try
            {
                if (bills.Id > 0)
                {
                    _db.Bills.Attach(bills);
                    _db.Entry(bills).Property(x => x.Status).IsModified = true;
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task UpdateDebts(Debts debts)
        {
            try
            {
                if (debts.Id > 0)
                {
                    _db.Debts.Attach(debts);
                    _db.Entry(debts).Property(x => x.Status).IsModified = true;
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task UpdateTableDebts(Debts debts)
        {
            try
            {
                if (debts.Id > 0)
                {
                    _db.Debts.Attach(debts);
                    if (!string.IsNullOrEmpty(debts?.Name))
                    {
                        _db.Entry(debts).Property(x => x.Name).IsModified = true;
                        await _db.SaveChangesAsync();

                    }
                    if(debts?.DateExpired.Year != 0001)
                    {
                        _db.Entry(debts).Property(x => x.DateExpired).IsModified = true;
                        await _db.SaveChangesAsync();

                    }
                    if (!string.IsNullOrEmpty(debts?.Value))
                    {
                        _db.Entry(debts).Property(x => x.Value).IsModified = true;
                        await _db.SaveChangesAsync();

                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public async Task UpdateTableBills(Bills bills)
        {
            try
            {
                if (bills.Id > 0)
                {
                    _db.Bills.Attach(bills);
                    if (!string.IsNullOrEmpty(bills?.Name))
                    {
                        _db.Entry(bills).Property(x => x.Name).IsModified = true;
                        await _db.SaveChangesAsync();

                    }
                    if (bills?.InitialDate.Year != 0001)
                    {
                        _db.Entry(bills).Property(x => x.InitialDate).IsModified = true;
                        await _db.SaveChangesAsync();

                    }
                    if (bills?.FinalDate.Year != 0001)
                    {
                        _db.Entry(bills).Property(x => x.FinalDate).IsModified = true;
                        await _db.SaveChangesAsync();

                    }
                    if (!string.IsNullOrEmpty(bills?.Value))
                    {
                        _db.Entry(bills).Property(x => x.Value).IsModified = true;
                        await _db.SaveChangesAsync();

                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public List<double> Echart(int id)
        {
            try
            {
                var days = new List<double>();
                for (int i = 1; i <= DateTime.Now.Day; i++)
                {
                    days.Add(_db.Earning.Where(x => !string.IsNullOrEmpty(x.EarningDay) && x.UserId == id && x.Date.Day == i).OrderBy(x => x.Date.Day).Select(x => double.Parse((x.EarningDay ?? "0"), new CultureInfo("pt-BR"))).ToList().Sum());
                }
                return days;


            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

        public List<double> Chart(int id)
        {
            try
            {
                var month = new List<double>();

                for (int i = 1; i <= 12; i++)
                {
                    
                    month.Add(_db.Earning.Where(x => x.Date.Month == i && !string.IsNullOrEmpty(x.EarningDay) && x.UserId == id).Select(x => double.Parse((x.EarningDay ?? "0,00"), new CultureInfo("pt-BR"))).ToList().Sum());
                }
                return month;
            }
            catch (Exception e)
            {

                throw new Exception("Not possible loading this content" + e.Message);
            }
        }

    }
}
