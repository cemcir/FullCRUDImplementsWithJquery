using FullCRUDImplementationWithJquery.Core.Models;
using FullCRUDImplementationWithJquery.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullCRUDImplementationWithJquery.Data.Repositories
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository{
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public DepartmentRepository(AppDbContext context) : base(context) { }

        public Department GetByDepartmentId(int id)
        {
            return this._appDbContext.Departments.Where(d => d.Id == id).
                         Include(s => s.Students).FirstOrDefault();
        }

        public Department FindByDepartmentName(string name)
        {
            return this._appDbContext.Departments.FromSql($"select * from Departments where DepartmentName= {name}").FirstOrDefault();
        }

        public List<Department> GetByDepartmentName(string departmentName)
        {
            return this._appDbContext.Departments.
                FromSql($"Select * from Departments where DepartmentName like {departmentName + '%'}").ToList();
        }

        public void UpdateDepartment(Department department)
        {
            this._appDbContext.Departments.Remove(department);
            this._appDbContext.SaveChanges();

            department.Id = 0;
            this._appDbContext.Departments.Add(department);
            this._appDbContext.SaveChanges();
        }
    }
}
