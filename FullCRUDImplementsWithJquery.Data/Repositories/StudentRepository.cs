using FullCRUDImplementationWithJquery.Core.Models;
using FullCRUDImplementationWithJquery.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullCRUDImplementationWithJquery.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public StudentRepository(AppDbContext context) : base(context) { }

        public List<Student> GetByStudentName(string name) {
            //string studentName = name;

            //return this._appDbContext.Students.FromSql($"select * from Students where StudentName like {name}+'%' ").ToList();
             return this._appDbContext.Students.FromSql($"Select * from Students where StudentName Like {name+'%'} ").Include(d=>d.Department).ToList();
        }

        public List<Student> GetStudentList() {
            return this._appDbContext.Students.
             Include(d => d.Department).ToList();
        }

        public void UpdateStudent(Student student)
        {
            this._appDbContext.Remove(student);
            this._appDbContext.SaveChanges();

            student.Id = 0;
            this._appDbContext.Add(student);
            this._appDbContext.SaveChanges();
        }

        public void AddStudent(Student student)
        {
            if (student.Id>0) {
                this._appDbContext.Remove(student);
                this._appDbContext.SaveChanges();

                student.Id = 0;
                this._appDbContext.Add(student);
                this._appDbContext.SaveChanges();
            }
            else {
                this._appDbContext.Add(student);
                this._appDbContext.SaveChanges();
            }
        }

        public Student GetByStudentId(int id)
        {
            return this._appDbContext.Students.Where(s => s.Id == id).
                Include(d => d.Department).FirstOrDefault();
        }
    }
}
