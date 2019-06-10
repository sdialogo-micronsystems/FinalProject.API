using FinalProject.API.Models;
using FinalProject.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeRepository employeeRepository, ILogger<EmployeesController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult GetEmployees()
        {
            try
            {
                return Ok(_employeeRepository.GetEmployees());
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name ="GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var employee = _employeeRepository.GetEmployee(id);

                if (employee == null)
                {
                    return StatusCode(400, $"Employee with id {id} not found");
                }

                return Ok(employee);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("create")]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employee)
        {
            try
            {
                if (employee == null)
                {
                    _logger.LogInformation("Invalid request body.");
                    return StatusCode(400, "Invalid request body.");
                }

                _logger.LogInformation("Validating request body...");
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Errors in validation: {ModelState}");
                    return BadRequest(ModelState);
                }

                var newEmployee = _employeeRepository.CreateEmployee(employee);

                return CreatedAtRoute("GetEmployee", new { id = newEmployee.Id }, newEmployee);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeValidationWrapper employee)
        {
            try
            {
                if (employee == null)
                {
                    _logger.LogInformation("Invalid request body.");
                    return StatusCode(400, "Invalid request body.");
                }

                _logger.LogInformation("Validating request body...");
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Errors in validation: {ModelState}");
                    return BadRequest(ModelState);
                }

                var updatedEmployee = _employeeRepository.UpdateEmployee(id, employee);
                if(updatedEmployee == null)
                {
                    return StatusCode(400, $"Employee with id {id} not found");
                }
                //else
                //{
                    return CreatedAtRoute("GetEmployee", new { id = updatedEmployee.Id }, updatedEmployee);
                //}
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var toDelete = _employeeRepository.DeleteEmployee(id);

                if (toDelete == null)
                {
                    return StatusCode(400, $"Employee with id {id} not found");
                }

                return Ok(toDelete);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
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
