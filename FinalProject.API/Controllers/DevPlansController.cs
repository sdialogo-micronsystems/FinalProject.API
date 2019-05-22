using FinalProject.API.Models;
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
        [HttpGet()]
        public IActionResult GetDevPlans()
        {
            return Ok(DevPlansDataStore.Current.DevPlans);
        }

        [HttpGet("{id}", Name = "GetDevPlan")]
        public IActionResult GetDevPlan(int id)
        {
            var devPlanReturn = DevPlansDataStore.Current.DevPlans.FirstOrDefault(devPlan => devPlan.Id == id);

            if(devPlanReturn == null)
            {
                return NotFound();
            }

            return Ok(devPlanReturn);
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

            var newDevPlan = new DevPlanDTO()
            {
                Id = devPlan.Id,
                Title = devPlan.Title,
                Description = devPlan.Description,
                EmployeeId = devPlan.EmployeeId,
                StatusCode = devPlan.StatusCode,
                DueDate = devPlan.DueDate
            };

            var currentDevPlans = DevPlansDataStore.Current.DevPlans;
            currentDevPlans.Add(newDevPlan);

            return CreatedAtRoute("GetDevPlan", new { id = newDevPlan.Id}, newDevPlan);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDevPlan(int id, [FromBody] DevPlanWrapperDTO devPlan)
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

            //full update
            devPlanToUpdate.Title = devPlan.Title;
            devPlanToUpdate.Description = devPlan.Description;
            devPlanToUpdate.EmployeeId = devPlan.EmployeeId;
            devPlanToUpdate.StatusCode = devPlan.StatusCode;
            devPlanToUpdate.DueDate = devPlan.DueDate;

            return NoContent();
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

            return NoContent();
        }
    }
}
