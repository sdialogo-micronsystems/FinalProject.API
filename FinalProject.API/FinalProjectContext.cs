using FinalProject.API.Entities.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Entities
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext(DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DevPlan>().ToTable("DevPlan");
            //modelBuilder.Entity<Employee>().ToTable("Employee");

            //modelBuilder.Entity<DevPlan>().HasData(
            //    new DevPlan()
            //    {
            //        Id = 4,
            //        Title = "Securing React Apps with Auth0",
            //        Description = "react-auth0-authentication-security",
            //        StatusCode = "Completed",
            //        EmployeeId = 1,
            //        DueDate = "2019-05-01"
            //    }
            //);

            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee()
            //    {
            //        Id = 4,
            //        LastName = "Jo",
            //        FirstName = "Yuri",
            //        MiddleName = "Yul",
            //        FullName = "Yuri Yul Jo",
            //        Archived = false,
            //        HireDate = "2019-05-01"
            //    }
            //);

            //modelBuilder.Entity<DevPlan>().Property(p => p.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Employee>().Property(p => p.Id).ValueGeneratedOnAdd();

            //modelBuilder.ForNpgsqlUseIdentityColumns();

            modelBuilder.ApplyConfiguration(new DevPlanConfiguration());
        }

        public DbSet<DevPlan> DevPlans { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
