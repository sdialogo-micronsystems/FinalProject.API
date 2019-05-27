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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=FinalProjectCodeFirstDB; Username=postgres; Password=password");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DevPlanConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public DbSet<DevPlan> DevPlans { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
