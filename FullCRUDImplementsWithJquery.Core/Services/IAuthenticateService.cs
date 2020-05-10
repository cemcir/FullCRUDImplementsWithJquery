using FullCRUDImplementationWithJquery.Core.Responses;
using FullCRUDImplementationWithJquery.Core.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Services
{
    public interface IAuthenticateService {

        BaseResponse<AccessToken> CreateAccessToken(string email, string password);

        BaseResponse<AccessToken> RemoveToken();
    }
}
