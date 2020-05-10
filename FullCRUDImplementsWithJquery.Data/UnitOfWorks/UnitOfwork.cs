using FullCRUDImplementationWithJquery.Core.Repositories;
using FullCRUDImplementationWithJquery.Core.UnitOfWorks;
using FullCRUDImplementationWithJquery.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Data.UnitOfWorks
{
    public class UnitOfWork:IUnitOfwork
    {
        private readonly AppDbContext _context;    
        private StudentRepository _studentRepository;
        private DepartmentRepository _departmentRepository;
        private UserRepository _userRepository;
        private IDbContextTransaction transaction;

        public IStudentRepository Students => _studentRepository = _studentRepository ?? new StudentRepository(_context);

        public IDepartmentRepository Departments => _departmentRepository = _departmentRepository ?? new DepartmentRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public UnitOfWork(AppDbContext appDbContext) {
            _context = appDbContext;
        }

        public void Commit() {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            transaction = this._context.Database.BeginTransaction();
        }

        public void TransactionCommit()
        {
            transaction.Commit();
        }

        public void RolBack()
        {
            transaction.Rollback();
        }
    }
}
