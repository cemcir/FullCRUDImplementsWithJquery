using FullCRUDImplementationWithJquery.Core.ErrorMessage;
using FullCRUDImplementationWithJquery.Core.Models;
using FullCRUDImplementationWithJquery.Core.Repositories;
using FullCRUDImplementationWithJquery.Core.Responses;
using FullCRUDImplementationWithJquery.Core.Services;
using FullCRUDImplementationWithJquery.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Service.Services
{
    public class DepartmentService:Service<Department>,IDepartmentService
    {
        public DepartmentService(IUnitOfwork unitOfWork, IRepository<Department> repository) : base(unitOfWork, repository) { }

        public BaseResponse<Department> FindByDepartmentName(string name)
        {
            try {
                Department d=this._unitOfWork.Departments.FindByDepartmentName(name);
                if (d == null) {
                    return new BaseResponse<Department>(d);
                }
                return new BaseResponse<Department>(new ErrorMessageCode().AlreadyExistEntity);
            }
            catch (Exception) {
                return new BaseResponse<Department>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<Department> GetByDepartmentId(int id) {
            try {
                var student=this._unitOfWork.Departments.GetByDepartmentId(id);
                if (student.Students.Count>0) {
                    return new BaseResponse<Department>(student);
                }
                return new BaseResponse<Department>(new ErrorMessageCode().NoEntity);
            }
            catch (Exception) {
                return new BaseResponse<Department>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<List<Department>> GetByDepartmentName(string departmentName)
        {
            try {
                var department = this._unitOfWork.Departments.GetByDepartmentName(departmentName);
                return new BaseResponse<List<Department>>(department);
            }
            catch (Exception) {
                return new BaseResponse<List<Department>>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<Department> UpdateDepartment(Department department)
        {
            this._unitOfWork.BeginTransaction();
            try {
                this._unitOfWork.Departments.UpdateDepartment(department);
                this._unitOfWork.TransactionCommit();
                return new BaseResponse<Department>(department);
            }
            catch (Exception) {
                this._unitOfWork.RolBack();
                return new BaseResponse<Department>(new ErrorMessageCode().ErrorCreated);
            }
        }
    }
}
