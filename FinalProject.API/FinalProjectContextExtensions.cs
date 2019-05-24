using FinalProject.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API
{
    public static class FinalProjectContextExtensions
    {
        public static void EnsureSeedDataForContext(this FinalProjectContext context)
        {
            if (context.DevPlans.Any())
            {
                return;
            }

            //init seed data
            var devPlans = new List<DevPlan>()
            {
                new DevPlan()
                {
                    Id = 1,
                    Title = "Securing React Apps with Auth0",
                    Description = "react-auth0-authentication-security",
                    StatusCode = "Completed",
                    EmployeeId = 1,
                    DueDate = "2019-05-01"
                },
                new DevPlan()
                {
                    Id = 2,
                    Title = "React: The Big Picture",
                    Description = "react-big-picture",
                    StatusCode = "In Progress",
                    EmployeeId = 2,
                    DueDate = "2019-05-01"
                }
            };

            var employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    LastName = "Jo",
                    FirstName = "Yuri",
                    MiddleName = "Yul",
                    FullName = "Yuri Yul Jo",
                    Archived = false,
                    HireDate = "2019-05-01"
                },
                new Employee()
                {
                    Id = 2,
                    LastName = "Choi",
                    FirstName = "Yena",
                    MiddleName = "Duck",
                    FullName = "Yena Duck Choi",
                    Archived = false,
                    HireDate = "2019-05-01"
                },
                new Employee()
                {
                    Id = 3,
                    LastName = "Kwon",
                    FirstName = "Eunbi",
                    MiddleName = "Leader",
                    FullName = "Eunbi Leader Kwon",
                    Archived = false,
                    HireDate = "2019-05-01"
                }
            };

            context.DevPlans.AddRange(devPlans);
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
