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
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Remember> Remembers { get; set; }



        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(e => e.Notes)
                        .WithOne(rs => rs.User)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Notes2)
                        .WithOne(rs => rs.User)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Notes3)
                        .WithOne(rs => rs.User)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Notes3)
                        .WithOne(rs => rs.User)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Earnings)
                        .WithOne(rs => rs.User)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Debts)
                        .WithOne(rs => rs.User)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Goal)
                        .WithOne(rs => rs.User)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Bills)
                        .WithOne(rs => rs.User)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                       .HasMany(e => e.Remembers)
                       .WithOne(rs => rs.User)
                       .OnDelete(DeleteBehavior.Cascade);
        }

    }
}