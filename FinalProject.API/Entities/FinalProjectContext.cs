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

        public DbSet<DevPlan> DevPlans { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
