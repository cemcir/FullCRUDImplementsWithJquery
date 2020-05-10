using FullCRUDImplementationWithJquery.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasAlternateKey(x => new {x.StudentNo });

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.StudentNo).IsRequired().HasMaxLength(11);

            builder.Property(x => x.StudentName).IsRequired().HasMaxLength(50);

            builder.ToTable("Students");
        }
    }
}
