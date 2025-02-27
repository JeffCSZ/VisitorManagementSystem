using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace VisitorManagementSystem.Authentication
{
    public class AppDbContext(DbContextOptions<AppDbContext> o, IConfiguration configuration) : IdentityDbContext<AppUser>(o)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mark AddOrUpdateAppUserModel as keyless if it doesn't require a primary key
            modelBuilder.Entity<AddOrUpdateAppUserModel>().HasNoKey();
            modelBuilder.Entity<LogInModel>().HasNoKey();
            //modelBuilder.Entity<AppUser>().HasNoKey();
        }

        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<AddOrUpdateAppUserModel> addOrUpdateAppUsers { get; set; }
        public DbSet<LogInModel> logInModels { get; set; }
    }
}
