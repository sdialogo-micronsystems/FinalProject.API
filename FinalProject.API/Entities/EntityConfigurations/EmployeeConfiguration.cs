using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Entities.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.FirstName)
                .IsRequired();
            builder.Property(prop => prop.MiddleName)
                .IsRequired();
            builder.Property(prop => prop.LastName)
                .IsRequired();
            builder.Property(prop => prop.FullName)
                .IsRequired();
            builder.Property(prop => prop.Archived)
                .IsRequired();
            builder.Property(prop => prop.HireDate)
                .IsRequired();
            builder.HasMany(prop => prop.DevPlans)
                .WithOne(d => d.Employee)
                .HasForeignKey(e => e.EmployeeId);
        }
    }
}
