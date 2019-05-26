using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.API.Entities;
using FinalProject.API.Models;
using Microsoft.AspNetCore.Mvc;
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
            _context.DevPlans.Add(Mapper.Map<DevPlan>(devPlan));
            _context.SaveChanges();

            return newDevPlan;
        }

        public DevPlanDTO UpdateDevPlan(int devPlanId, DevPlanValidationWrapper devPlan)
        {
            var toUpdate = _context.DevPlans.Where(d => d.Id == devPlanId).FirstOrDefault();
            Mapper.Map(devPlan, toUpdate);
            _context.SaveChanges();

            return Mapper.Map<DevPlanDTO>(toUpdate);
        }

        public void DeleteDevPlan(int devPlanId)
        {
            var toDelete = _context.DevPlans.Where(d => d.Id == devPlanId).FirstOrDefault();
            _context.DevPlans.Remove(toDelete);
            _context.SaveChanges();
        }
    }
}
