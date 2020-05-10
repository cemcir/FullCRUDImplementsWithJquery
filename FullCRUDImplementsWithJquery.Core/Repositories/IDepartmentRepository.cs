using FullCRUDImplementationWithJquery.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Repositories
{
    public interface IDepartmentRepository:IRepository<Department> {

        Department GetByDepartmentId(int id);

        Department FindByDepartmentName(string name);

        List<Department> GetByDepartmentName(string departmentName);

        void UpdateDepartment(Department department);
    }
}
