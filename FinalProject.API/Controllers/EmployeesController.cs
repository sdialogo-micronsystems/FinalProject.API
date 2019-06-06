using FinalProject.API.Models;
using FinalProject.API.Services;
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
        private IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet()]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeRepository.GetEmployees());
        }

        [HttpGet("{id}", Name ="GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if(employee == null) return NotFound(); 

            return Ok(employee);
        }

        [HttpPost("create")]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employee)
        {
            if (employee == null) return BadRequest(); 
            if (!ModelState.IsValid) return BadRequest(ModelState); 

            var newEmployee = _employeeRepository.CreateEmployee(employee);
            return CreatedAtRoute("GetEmployee", new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeValidationWrapper employee)
        {
            if (employee == null) return BadRequest(); 
            if (!ModelState.IsValid) return BadRequest(ModelState);  
            if (_employeeRepository.GetEmployee(id) == null) return NotFound(); 

            var updatedEmployee = _employeeRepository.UpdateEmployee(id, employee);
            return CreatedAtRoute("GetEmployee", new { id = updatedEmployee.Id }, updatedEmployee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var toDelete = _employeeRepository.GetEmployee(id);
            if (toDelete == null) return NotFound();
            _employeeRepository.DeleteEmployee(id);

            return Ok(toDelete);
        }

        [HttpGet("assignedDevPlans/{id}")]
        public IActionResult GetAssignedDevPlans(int id)
        {
            if (_employeeRepository.GetEmployee(id) == null) return NotFound();
            var result = _employeeRepository.GetAssignedDevPlans(id);

            return Ok(result);
        }
    }
}
