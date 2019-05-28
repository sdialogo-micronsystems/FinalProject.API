using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using FinalProject.API.Entities;
using FinalProject.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinalProject.API
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                //.AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();

            var connectionString = Startup.Configuration["connectionStrings:finalProjectDBConnectionString"];
            services.AddDbContext<FinalProjectContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IDevPlanRepository, DevPlanRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FinalProjectContext finalProjectContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            finalProjectContext.EnsureSeedDataForContext();
            app.UseStatusCodePages();

            app.UseCors(
                options => options.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();
            
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Entities.DevPlan, Models.DevPlanViewModel>();
                cfg.CreateMap<Models.DevPlanDTO, Entities.DevPlan>();
                cfg.CreateMap<Models.DevPlanValidationWrapper, Entities.DevPlan>();
                cfg.CreateMap<Models.DevPlanValidationWrapper, Models.DevPlanDTO>();
                cfg.CreateMap<Models.DevPlanViewModel, Entities.DevPlan>();
                cfg.CreateMap<Entities.Employee, Models.EmployeeViewModel>();
                cfg.CreateMap<Models.EmployeeDTO, Entities.Employee>();
                cfg.CreateMap<Models.EmployeeValidationWrapper, Entities.Employee>();
                cfg.CreateMap<Models.EmployeeValidationWrapper, Models.EmployeeDTO>();
                cfg.CreateMap<Models.EmployeeViewModel, Entities.Employee>();
            });
        }
    }
}
