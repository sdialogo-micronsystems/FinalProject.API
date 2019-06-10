using FinalProject.API.Entities;
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
    [Route("api/devPlans")]
    public class DevPlansController : Controller
    {
        private IDevPlanRepository _devPlanRepository;
        private ILogger<DevPlansController> _logger;

        public DevPlansController(IDevPlanRepository devPlanRepository, ILogger<DevPlansController> logger)
        {
            _devPlanRepository = devPlanRepository;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult GetDevPlans()
        {
            try
            {
                return Ok(_devPlanRepository.GetDevPlans());
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "GetDevPlan")]
        public IActionResult GetDevPlan(int id)
        {
            try
            {
                var devPlan = _devPlanRepository.GetDevPlan(id);

                if (devPlan == null)
                {
                    return StatusCode(400, $"DevPlan with id {id} not found");
                }

                return Ok(devPlan);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("create")] 
        public IActionResult CreateDevPlan([FromBody] DevPlanDTO devPlan)
        {
            try
            {
                if (devPlan == null)
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

                var newDevPlan = _devPlanRepository.CreateDevPlan(devPlan);

                return CreatedAtRoute("GetDevPlan", new { id = newDevPlan.Id }, newDevPlan);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDevPlan(int id, [FromBody] DevPlanValidationWrapper devPlan)
        {
            try
            {
                if (devPlan == null)
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

                var updatedDevPlan = _devPlanRepository.UpdateDevPlan(id, devPlan);

                if (updatedDevPlan == null)
                {
                    return StatusCode(400, $"DevPlan with id {id} not found");
                }
                return CreatedAtRoute("GetDevPlan", new { id = updatedDevPlan.Id }, updatedDevPlan);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDevPlan(int id)
        {
            try
            {
                var toDelete = _devPlanRepository.DeleteDevPlan(id);

                if (toDelete == null)
                {
                    return StatusCode(400, $"DevPlan with id {id} not found");
                }

                return Ok(toDelete);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
