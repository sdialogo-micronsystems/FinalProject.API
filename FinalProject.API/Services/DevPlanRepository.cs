using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.API.Entities;
using FinalProject.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinalProject.API.Services
{
    public class DevPlanRepository : IDevPlanRepository
    {
        private FinalProjectContext _context;
        private ILogger<DevPlanRepository> _logger;

        public object ModelState { get; private set; }

        public DevPlanRepository(FinalProjectContext context, ILogger<DevPlanRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<DevPlanViewModel> GetDevPlans()
        {
            _logger.LogInformation("Fetching all Development Plans from database...");
            var devPlanEntities = _context.DevPlans.OrderBy(devPlan => devPlan.Id).ToList();

            _logger.LogInformation($"Fetched {devPlanEntities.Count()} development plans.");
            return Mapper.Map<IEnumerable<DevPlanViewModel>>(devPlanEntities);
        }
        public DevPlanViewModel GetDevPlan(int devPlanId)
        {
            _logger.LogInformation($"Finding development plan with id {devPlanId}...");
            var devPlanEntity = _context.DevPlans.Where(d => d.Id == devPlanId).FirstOrDefault();

            if (devPlanEntity == null)
            {
                _logger.LogInformation($"Development Plan with id {devPlanId} does not exist.");
                return null;
            }

            return Mapper.Map<DevPlanViewModel>(devPlanEntity);
        }

        public DevPlanViewModel CreateDevPlan(DevPlanDTO devPlan)
        {
            _logger.LogInformation("Creating Development Plan...");
            _context.DevPlans.Add(Mapper.Map<DevPlan>(devPlan));
            _context.SaveChanges();

            _logger.LogInformation("Successfully created new development plan.");
            return Mapper.Map<DevPlanViewModel>(devPlan);
        }

        public DevPlanDTO UpdateDevPlan(int devPlanId, DevPlanValidationWrapper devPlan)
        {
            var toUpdate = _context.DevPlans.Where(d => d.Id == devPlanId).FirstOrDefault();

            if (toUpdate == null)
            {
                _logger.LogInformation($"Development Plan with id {devPlanId} does not exist.");
                return null;
            }

            _logger.LogInformation($"Updating development plan with id {devPlanId}...");
            Mapper.Map(devPlan, toUpdate);
            _context.SaveChanges();

            _logger.LogInformation($"Successfully updated development plan with id {devPlanId}.");
            return Mapper.Map<DevPlanDTO>(toUpdate);
        }

        public DevPlanViewModel DeleteDevPlan(int devPlanId)
        {

            var toDelete = _context.DevPlans.Where(e => e.Id == devPlanId).FirstOrDefault();
            
            if (toDelete == null)
            {
                _logger.LogInformation($"Development Plan with id {devPlanId} does not exist.");
                return null;
            }

            _logger.LogInformation($"Deleting development plan with id {devPlanId}...");
            _context.DevPlans.Remove(toDelete);
            _context.SaveChanges();

            _logger.LogInformation($"Successfully deleted development plan with id {devPlanId}.");
            return Mapper.Map<DevPlanViewModel>(toDelete);
        }
    }
}
