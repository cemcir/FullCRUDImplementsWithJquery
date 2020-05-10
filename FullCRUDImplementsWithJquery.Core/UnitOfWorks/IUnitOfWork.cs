using FullCRUDImplementationWithJquery.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.UnitOfWorks
{
    public interface IUnitOfwork {

        IStudentRepository Students { get; }

        IDepartmentRepository Departments { get; }

        IUserRepository Users { get; }

        void BeginTransaction();

        void TransactionCommit();

        void RolBack();

        void Commit();
    }
}
