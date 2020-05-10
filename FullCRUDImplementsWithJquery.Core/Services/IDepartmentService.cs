using FullCRUDImplementationWithJquery.Core.Models;
using FullCRUDImplementationWithJquery.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Services
{
    public interface IDepartmentService:IService<Department> {

        BaseResponse<Department> GetByDepartmentId(int id);

        BaseResponse<Department> FindByDepartmentName(string name);

        BaseResponse<List<Department>> GetByDepartmentName(string departmentName);

        BaseResponse<Department> UpdateDepartment(Department department);
    }
}
