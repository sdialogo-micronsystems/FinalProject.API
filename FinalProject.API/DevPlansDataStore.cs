using FinalProject.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API
{
    public class DevPlansDataStore
    {
        public static DevPlansDataStore Current { get; } = new DevPlansDataStore();
        public List<DevPlanDTO> DevPlans { get; set; }

        public DevPlansDataStore()
        {
            DevPlans = new List<DevPlanDTO>()
            {
                new DevPlanDTO()
                {
                    Id = 1,
                    Title = "Securing React Apps with Auth0",
                    Description = "react-auth0-authentication-security",
                    StatusCode = "Completed",
                    EmployeeId = 1,
                    DueDate = "2019-05-01"
                },
                new DevPlanDTO()
                {
                    Id = 2,
                    Title = "React: The Big Picture",
                    Description = "react-big-picture",
                    StatusCode = "In Progress",
                    EmployeeId = 2,
                    DueDate = "2019-05-01"
                }
            };
        }
    }
}
