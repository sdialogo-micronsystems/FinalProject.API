using FinalProject.API.Entities;
using FinalProject.API.Models;
using FinalProject.API.Services;
using Microsoft.AspNetCore.Mvc;
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

        public DevPlansController(IDevPlanRepository devPlanRepository)
        {
            _devPlanRepository = devPlanRepository;
        }

        [HttpGet()]
        public IActionResult GetDevPlans()
        {
            return Ok(_devPlanRepository.GetDevPlans());
        }

        [HttpGet("{id}", Name = "GetDevPlan")]
        public IActionResult GetDevPlan(int id)
        {
            var devPlan = _devPlanRepository.GetDevPlan(id);
            if(devPlan == null)
            {
                return NotFound();
            }
            return Ok(devPlan);
        }

        [HttpPost("create")] 
        public IActionResult CreateDevPlan([FromBody] DevPlanDTO devPlan)
        {
            if (devPlan == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDevPlan = _devPlanRepository.CreateDevPlan(devPlan);

            return CreatedAtRoute("GetDevPlan", new { id = newDevPlan.Id}, newDevPlan);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDevPlan(int id, [FromBody] DevPlanValidationWrapper devPlan)
        {
            if (devPlan == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var devPlanToUpdate = DevPlansDataStore.Current.DevPlans.FirstOrDefault(d => d.Id == id);
            if(devPlanToUpdate == null)
            {
                return NotFound();
            }

            devPlanToUpdate.Title = devPlan.Title;
            devPlanToUpdate.Description = devPlan.Description;
            devPlanToUpdate.EmployeeId = devPlan.EmployeeId;
            devPlanToUpdate.StatusCode = devPlan.StatusCode;
            devPlanToUpdate.DueDate = devPlan.DueDate;

            return CreatedAtRoute("GetDevPlan", new { id = devPlanToUpdate.Id }, devPlanToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDevPlan(int id)
        {
            var devPlan = DevPlansDataStore.Current.DevPlans.FirstOrDefault(d => d.Id == id);

            if (devPlan == null)
            {
                return NotFound();
            }

            var currentDevPlans = DevPlansDataStore.Current.DevPlans;
            currentDevPlans.Remove(devPlan);

            return GetDevPlans();
        }
    }
}
