using FullCRUDImplementationWithJquery.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Repositories
{
    public interface IStudentRepository:IRepository<Student> {

        List<Student> GetByStudentName(string name);

        List<Student> GetStudentList();

        void UpdateStudent(Student student);

        void AddStudent(Student student);

        Student GetByStudentId(int id);
    }
}
