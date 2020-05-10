using FullCRUDImplementationWithJquery.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => new { x.DepartmentName });

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.DepartmentName).IsRequired().HasMaxLength(50);

            builder.ToTable("Departments");
        }
    }
}
