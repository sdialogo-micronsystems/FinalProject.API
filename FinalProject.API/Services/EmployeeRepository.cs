using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            return Mapper.Map<IEnumerable<EmployeeViewModel>>(employeeEntities);
        }
        public EmployeeViewModel GetEmployee(int employeeId)
        {
            var employeeEntity = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            if(employeeEntity == null)
            {
                return null;
            }
            return Mapper.Map<EmployeeViewModel>(employeeEntity);
        }
    }
}
