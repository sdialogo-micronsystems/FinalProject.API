using FinalProject.API.Models;
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

        [HttpGet("{id}", Name ="GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            var employeeReturn = EmployeesDataStore.Current.Employees.FirstOrDefault(employee => employee.Id == id);

            if (employeeReturn == null)
            {
                return NotFound();
            }

            return Ok(employeeReturn);
        }

        [HttpPost("create")]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEmployee = new EmployeeDTO()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                FullName = employee.FullName,
                Archived = employee.Archived,
                HireDate = employee.HireDate
    };

            var currentEmployees = EmployeesDataStore.Current.Employees;
            currentEmployees.Add(newEmployee);

            return CreatedAtRoute("GetEmployee", new { id = newEmployee.Id }, newEmployee);
        }
    }
}
