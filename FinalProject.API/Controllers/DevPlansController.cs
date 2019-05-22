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
    }
}
