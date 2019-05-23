using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.API.Entities;
using FinalProject.API.Models;

namespace FinalProject.API.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private FinalProjectContext _context;
        public EmployeeRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            var employeeEntities = _context.Employees.OrderBy(employee => employee.Id).ToList();
            var employees = new List<EmployeeViewModel>();

            foreach (var employeeEntity in employeeEntities)
            {
                employees.Add(new EmployeeViewModel
                {
                    Id = employeeEntity.Id,
                    FirstName = employeeEntity.FirstName,
                    MiddleName = employeeEntity.MiddleName,
                    LastName = employeeEntity.LastName,
                    FullName = employeeEntity.FullName,
                    Archived = employeeEntity.Archived,
                    HireDate = employeeEntity.HireDate
                });
            }

            return employees;
        }
        public EmployeeViewModel GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
