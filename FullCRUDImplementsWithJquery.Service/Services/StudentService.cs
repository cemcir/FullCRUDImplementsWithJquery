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
    public class StudentService : Service<Student>, IStudentService
    {

        public StudentService(IUnitOfwork unitOfWork, IRepository<Student> repository) : base(unitOfWork, repository) { }

        public BaseResponse<Student> AddStudent(Student student)
        {
            this._unitOfWork.BeginTransaction();
            try {
                this._unitOfWork.Students.AddStudent(student);
                this._unitOfWork.TransactionCommit();
                return new BaseResponse<Student>(student);
            }
            catch (Exception) {
                this._unitOfWork.RolBack();
                return new BaseResponse<Student>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<Student> GetByStudentId(int id)
        {
            try
            {
                var student = this._unitOfWork.Students.GetByStudentId(id);
                if (student != null) {
                    return new BaseResponse<Student>(student);
                }
                return new BaseResponse<Student>(new ErrorMessageCode().NoEntity);
            }
            catch (Exception)
            {
                return new BaseResponse<Student>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<List<Student>> GetByStudentName(string name)
        {
            try {
                var students=this._unitOfWork.Students.GetByStudentName(name);
                if (students.Count > 0) {
                    return new BaseResponse<List<Student>>(students);
                }
                return new BaseResponse<List<Student>>(new ErrorMessageCode().NoEntity);
            }
            catch (Exception) {
                return new BaseResponse<List<Student>>(new ErrorMessageCode().ErrorCreated);
            }
        }

        public BaseResponse<List<Student>> GetStudentList() {
            try {
                var students = this._unitOfWork.Students.GetStudentList();
                if (students.Count > 0) {
                    return new BaseResponse<List<Student>>(students);
                }
                else if (students.Count == 0) {
                    return new BaseResponse<List<Student>>(students);
                }
                else {
                    return new BaseResponse<List<Student>>(new ErrorMessageCode().ErrorCreated);
                }
            }
            catch (Exception) {
                return new BaseResponse<List<Student>>(new ErrorMessageCode().AlreadyExistEntity);
            }
        }

        public BaseResponse<Student> UpdateStudent(Student student)
        {
            this._unitOfWork.BeginTransaction();
            try {
                this._unitOfWork.Students.UpdateStudent(student);
                //throw new Exception(); // transaction denemesi yaptık
                this._unitOfWork.TransactionCommit();
                //this._unitOfWork.Commit();
                return new BaseResponse<Student>(student);
            }
            catch (Exception) {
                this._unitOfWork.RolBack();
                return new BaseResponse<Student>(new ErrorMessageCode().ErrorCreated);
            }
        }
    }
}
