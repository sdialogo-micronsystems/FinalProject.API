using FinalProject.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API
{
    public class EmployeesDataStore
    {
        public static EmployeesDataStore Current { get; } = new EmployeesDataStore();
        public List<EmployeeDTO> Employees { get; set; }

        public EmployeesDataStore()
        {
            Employees = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id = 1,
                    LastName = "Jo",
                    FirstName = "Yuri",
                    MiddleName = "Yul",
                    FullName = "Yuri Yul Jo",
                    Archived = false,
                    HireDate = "2019-05-01"
                },
                new EmployeeDTO()
                {
                    Id = 2,
                    LastName = "Choi",
                    FirstName = "Yena",
                    MiddleName = "Duck",
                    FullName = "Yena Duck Choi",
                    Archived = false,
                    HireDate = "2019-05-01"
                }
            };
        }
    }
}
