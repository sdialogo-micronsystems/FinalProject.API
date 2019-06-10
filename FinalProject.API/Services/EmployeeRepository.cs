using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.API.Controllers;
using FinalProject.API.Entities;
using FinalProject.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinalProject.API.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private FinalProjectContext _context;
        private ILogger<EmployeeRepository> _logger;
        public EmployeeRepository(FinalProjectContext context, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            _logger.LogInformation("Fetching all Employees from database...");
            var employeeEntities = _context.Employees.OrderBy(employee => employee.Id).ToList();

            _logger.LogInformation($"Fetched {employeeEntities.Count()} employees.");
            return Mapper.Map<IEnumerable<EmployeeViewModel>>(employeeEntities);
        }
        public EmployeeViewModel GetEmployee(int employeeId)
        {
            _logger.LogInformation($"Finding employee with id {employeeId}...");
            var employeeEntity = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

            if (employeeEntity == null)
            {
                _logger.LogInformation($"Employee with id {employeeId} does not exist.");
                return null;
            }

            return Mapper.Map<EmployeeViewModel>(employeeEntity);
        }

        public EmployeeViewModel CreateEmployee(EmployeeDTO employee)
        {
            _logger.LogInformation("Creating Employee...");
            _context.Employees.Add(Mapper.Map<Employee>(employee));
            _context.SaveChanges();

            _logger.LogInformation("Successfully created new employee.");
            return Mapper.Map<EmployeeViewModel>(employee);
        }

        public EmployeeDTO UpdateEmployee(int employeeId, EmployeeValidationWrapper employee)
        {
            var toUpdate = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

            if(toUpdate == null) {
                _logger.LogInformation($"Employee with id {employeeId} does not exist.");
                return null;
            }

            _logger.LogInformation($"Updating employee with id {employeeId}...");
            Mapper.Map(employee, toUpdate);
            _context.SaveChanges();

            _logger.LogInformation($"Successfully updated employee with id {employeeId}.");
            return Mapper.Map<EmployeeDTO>(toUpdate);
        }

        public EmployeeViewModel DeleteEmployee(int employeeId)
        {
            var toDelete = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            
            if (toDelete == null)
            {
                _logger.LogInformation($"Employee with id {employeeId} does not exist.");
                return null;
            }

            _logger.LogInformation($"Deleting employee with id {employeeId}...");
            _context.Employees.Remove(toDelete);
            _context.SaveChanges();

            _logger.LogInformation($"Successfully deleted employee with id {employeeId}.");
            return Mapper.Map<EmployeeViewModel>(toDelete);
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
