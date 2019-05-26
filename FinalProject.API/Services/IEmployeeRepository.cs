using FinalProject.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeViewModel> GetEmployees();
        EmployeeViewModel GetEmployee(int employeeId);
        EmployeeViewModel CreateEmployee(EmployeeDTO employee);
        EmployeeDTO UpdateEmployee(int employeeId, EmployeeValidationWrapper employee);
        void DeleteEmployee(int employeeId);
    }
}
