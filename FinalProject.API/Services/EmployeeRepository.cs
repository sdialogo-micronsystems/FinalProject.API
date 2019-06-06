using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.API.Entities;
using FinalProject.API.Models;
using Microsoft.EntityFrameworkCore;

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
            //var employeeEntities = _context.Employees.Include(c => c.DevPlans).OrderBy(employee => employee.Id).ToList();
            var employeeEntities = _context.Employees.OrderBy(employee => employee.Id).ToList();
            return Mapper.Map<IEnumerable<EmployeeViewModel>>(employeeEntities);
        }
        public EmployeeViewModel GetEmployee(int employeeId)
        {
            var employeeEntity = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            if(employeeEntity == null) return null; 
            return Mapper.Map<EmployeeViewModel>(employeeEntity);
        }

        public EmployeeViewModel CreateEmployee(EmployeeDTO employee)
        {
            var newEmployee = Mapper.Map<EmployeeViewModel>(employee);
            _context.Employees.Add(Mapper.Map<Employee>(newEmployee));
            _context.SaveChanges();

            return newEmployee;
        }

        public EmployeeDTO UpdateEmployee(int employeeId, EmployeeValidationWrapper employee)
        {
            var toUpdate = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            Mapper.Map(employee, toUpdate);
            _context.SaveChanges();

            return Mapper.Map<EmployeeDTO>(toUpdate);
        }

        public void DeleteEmployee(int employeeId)
        {
            var toDelete = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            _context.Employees.Remove(toDelete);
            _context.SaveChanges();
        }

        public IEnumerable<DevPlanViewModel> GetAssignedDevPlans(int employeeId)
        {
            var assignedDevPlans = _context.Employees
                                    .Where(e => e.Id == employeeId)
                                    .Select(col => col.DevPlans).FirstOrDefault().ToList();
            return Mapper.Map<IEnumerable<DevPlanViewModel>>(assignedDevPlans);
        }
    }
}
