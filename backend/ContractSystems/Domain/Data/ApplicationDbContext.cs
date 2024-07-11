using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Password> Passwords => Set<Password>();
        public DbSet<PasswordType> PasswordTypes => Set<PasswordType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}