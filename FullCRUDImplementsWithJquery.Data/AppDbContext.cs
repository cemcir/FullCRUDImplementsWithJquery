using FullCRUDImplementationWithJquery.Core.Entities;
using FullCRUDImplementationWithJquery.Core.Models;
using FullCRUDImplementationWithJquery.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Data
{
    public class AppDbContext :DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            /*
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Student>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Student>().Property(x => x.Name).HasMaxLength(100);

            modelBuilder.Entity<Student>().Property(x => x.SurName).HasMaxLength(100);
            */
        }

    }
}
