using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechnoManagementAssignment.Models;

namespace TechnoManagementAssignment.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = "2", Name = "Employee", NormalizedName = "EMPLOYEE" }
            );

            builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "1",
                UserName = "Ahmed Elshenawy",
                NormalizedUserName = "AHMED ELSHENAWY",
                Email = "elshenawy1ahmed@gmail.com",
                NormalizedEmail = "ELSHENAWY1AHMED@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "P@ssw0rd"),
                SecurityStamp = string.Empty
            }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = "1", RoleId = "1" } 
            );

            builder.Entity<Department>().HasData(
            new Department {  Id = 1 , Name = "SD"},
            new Department { Id = 2, Name = ".Net" },
            new Department { Id = 3, Name = "OS" },
            new Department { Id = 4, Name = "PHP" }
            );

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

    }
}
