using FullCRUDImplementationWithJquery.Core.Entities;
using FullCRUDImplementationWithJquery.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Services
{
    public interface IUserService:IService<User>
    {
        BaseResponse<User> FindByUserNameAndPassword(string userName,string password);
    }
}
