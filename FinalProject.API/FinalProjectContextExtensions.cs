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

            var devPlans = new List<DevPlan>()
            {
                new DevPlan()
                {
                    Id = 1,
                    Title = "Securing React Apps with Auth0",
                    Description = "react-auth0-authentication-security",
                    StatusCode = "Completed",
                    EmployeeId = 1,
                    DueDate = new DateTime(2019,05,01)
                },
                new DevPlan()
                {
                    Id = 2,
                    Title = "React: The Big Picture",
                    Description = "react-big-picture",
                    StatusCode = "In Progress",
                    EmployeeId = 2,
                    DueDate = new DateTime(2019,08,07)
                },
                new DevPlan()
                {
                    Id = 3,
                    Title = "Creating Reusable React Components",
                    Description = "react-creating-reusable-components",
                    StatusCode = "Not Started",
                    EmployeeId = 3,
                    DueDate = new DateTime(2019,10,12)
                },
                new DevPlan()
                {
                    Id = 4,
                    Title = "Building a JavaScript Development Environment",
                    Description = "javascript-development-environment",
                    StatusCode = "Not Started",
                    EmployeeId = 4,
                    DueDate = new DateTime(2019,12,06)
                },
                new DevPlan()
                {
                    Id = 5,
                    Title = "Building Applications with React and Redux",
                    Description = "react-redux-react-router-es6",
                    StatusCode = "Not Started",
                    EmployeeId = 3,
                    DueDate = new DateTime(2019,11,19)
                },
                new DevPlan()
                {
                    Id = 6,
                    Title = "Building Applications in React and Flux",
                    Description = "react-flux-building-applications",
                    StatusCode = "Not Started",
                    EmployeeId = 4,
                    DueDate = new DateTime(2019,12,13)
                }
            };

            var employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    LastName = "Dialogo",
                    FirstName = "Sandra",
                    MiddleName = "Surita",
                    FullName = "Sandra Surita Dialogo",
                    Archived = false,
                    HireDate = new DateTime(2019,05,01)
                },
                new Employee()
                {
                    Id = 2,
                    LastName = "Tingson",
                    FirstName = "Patrixia",
                    MiddleName = "Bearis",
                    FullName = "Patrixia Bearis Tingson",
                    Archived = false,
                    HireDate = new DateTime(2019,05,01)
                },
                new Employee()
                {
                    Id = 3,
                    LastName = "Leonardo",
                    FirstName = "Isaiah",
                    MiddleName = "Valentin",
                    FullName = "Isaiah Valentin Leonardo",
                    Archived = false,
                    HireDate = new DateTime(2019,08,07)
                },
                new Employee()
                {
                    Id = 4,
                    LastName = "Dialogo",
                    FirstName = "Danica",
                    MiddleName = "Surita",
                    FullName = "Danica Surita Dialogo",
                    Archived = false,
                    HireDate = new DateTime(2019,12,06)
                }
            };

            context.DevPlans.AddRange(devPlans);
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
