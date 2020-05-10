using FullCRUDImplementationWithJquery.Core.Models;
using FullCRUDImplementationWithJquery.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Services
{
    public interface IStudentService:IService<Student>
    {
        BaseResponse<List<Student>> GetByStudentName(string name);

        BaseResponse<List<Student>> GetStudentList();

        BaseResponse<Student> UpdateStudent(Student student);

        BaseResponse<Student> AddStudent(Student student);

        BaseResponse<Student> GetByStudentId(int id);
    }
}
