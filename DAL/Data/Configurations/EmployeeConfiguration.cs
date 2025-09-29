using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Code).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Address).HasMaxLength(200);
            builder.Property(e => e.Salary).IsRequired();

        }
    }
}
