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

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeWrapperDTO employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeToUpdate = EmployeesDataStore.Current.Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            //full update
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.MiddleName = employee.MiddleName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.FullName = employee.FullName;
            employeeToUpdate.Archived = employee.Archived;
            employeeToUpdate.HireDate = employee.HireDate;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = EmployeesDataStore.Current.Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            var currentEmployees = EmployeesDataStore.Current.Employees;
            currentEmployees.Remove(employee);

            return NoContent();
        }
    }
}
