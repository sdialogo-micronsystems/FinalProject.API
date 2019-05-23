using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.API.Entities;
using FinalProject.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.API.Services
{
    public class DevPlanRepository : IDevPlanRepository
    {
        private FinalProjectContext _context;
        public DevPlanRepository(FinalProjectContext context)
        {
            _context = context;
        }

        public IEnumerable<DevPlanViewModel> GetDevPlans()
        {
            var devPlanEntities = _context.DevPlans.OrderBy(devPlan => devPlan.Id).ToList();
            var devPlans = new List<DevPlanViewModel>();

            foreach (var devPlanEntity in devPlanEntities)
            {
                devPlans.Add(new DevPlanViewModel
                {
                    Id = devPlanEntity.Id,
                    Title = devPlanEntity.Title,
                    Description = devPlanEntity.Description,
                    StatusCode = devPlanEntity.StatusCode,
                    EmployeeId = devPlanEntity.EmployeeId,
                    DueDate = devPlanEntity.DueDate
                });
            }

            return devPlans;
        }
        public DevPlanViewModel GetDevPlan(int devPlanId)
        {
            var devPlanEntity = _context.DevPlans.Where(d => d.Id == devPlanId).FirstOrDefault();

            if (devPlanEntity == null)
            {
                return null;
            }

            var devPlan = new DevPlanViewModel {
                Id = devPlanEntity.Id,
                Title = devPlanEntity.Title,
                Description = devPlanEntity.Description,
                DueDate = devPlanEntity.DueDate,
                EmployeeId = devPlanEntity.EmployeeId,
                StatusCode = devPlanEntity.StatusCode
            };

            return devPlan;
        }
    }
}
