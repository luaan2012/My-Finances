using Microsoft.EntityFrameworkCore;
using SistemaContas.Models;

namespace SistemaContas.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Note2> Note2 { get; set; }
        public DbSet<Note3> Note3 { get; set; }
        public DbSet<Debts> Debts { get; set; }
        public DbSet<Earning> Earning { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<Bills> Bills { get; set; }



        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

    }
}