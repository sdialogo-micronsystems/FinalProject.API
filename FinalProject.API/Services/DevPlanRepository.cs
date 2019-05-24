using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.API.Entities;
using FinalProject.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.API.Services
{
    public class DevPlanRepository : IDevPlanRepository
    {
        private FinalProjectContext _context;

        public object ModelState { get; private set; }

        public DevPlanRepository(FinalProjectContext context)
        {
            _context = context;
        }
        public IEnumerable<DevPlanViewModel> GetDevPlans()
        {
            var devPlanEntities = _context.DevPlans.OrderBy(devPlan => devPlan.Id).ToList();
            return Mapper.Map<IEnumerable<DevPlanViewModel>>(devPlanEntities);
        }
        public DevPlanViewModel GetDevPlan(int devPlanId)
        {
            var devPlanEntity = _context.DevPlans.Where(d => d.Id == devPlanId).FirstOrDefault();
            if (devPlanEntity == null)
            {
                return null;
            }
            return Mapper.Map<DevPlanViewModel>(devPlanEntity);
        }

        public DevPlanViewModel CreateDevPlan(DevPlanDTO devPlan)
        {
            var newDevPlan = Mapper.Map<DevPlanViewModel>(devPlan);
            var currentDevPlans = GetDevPlans();
            currentDevPlans.ToList().Add(newDevPlan);

            return newDevPlan;
        }
    }
}
