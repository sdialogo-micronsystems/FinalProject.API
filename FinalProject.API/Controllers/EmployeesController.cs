using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Controllers
{
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        [HttpGet()]
        public IActionResult GetEmployees()
        {
            return Ok(EmployeesDataStore.Current.Employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employeeReturn = EmployeesDataStore.Current.Employees.FirstOrDefault(employee => employee.Id == id);

            if (employeeReturn == null)
            {
                return NotFound();
            }

            return Ok(employeeReturn);
        }
    }
}
