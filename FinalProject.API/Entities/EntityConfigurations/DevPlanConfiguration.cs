using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Entities.EntityConfigurations
{
    public class DevPlanConfiguration : IEntityTypeConfiguration<DevPlan>
    {
        public void Configure(EntityTypeBuilder<DevPlan> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id).HasColumnType("SERIAL");
            builder.Property(prop => prop.Title);
            //.IsRequired();
            builder.Property(prop => prop.Description);
            //.IsRequired();
            builder.Property(prop => prop.StatusCode);
            //.IsRequired();
            builder.Property(prop => prop.EmployeeId)
                .HasColumnType("INTEGER");
                //.IsRequired();
            builder.Property(prop => prop.DueDate);
                //.IsRequired();
        }
    }
}
