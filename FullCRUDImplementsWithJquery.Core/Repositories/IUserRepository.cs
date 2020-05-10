using FullCRUDImplementationWithJquery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Repositories
{
    public interface IUserRepository:IRepository<User> {

        User FindByUserNameAndPassword(string userName,string password);
    }
}
