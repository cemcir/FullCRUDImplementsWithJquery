using FullCRUDImplementationWithJquery.Core.Entities;
using FullCRUDImplementationWithJquery.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullCRUDImplementationWithJquery.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public UserRepository(AppDbContext context) : base(context) { }

        public User FindByUserNameAndPassword(string userName, string password) {
            return this._appDbContext.Users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();

        }
    }
}
