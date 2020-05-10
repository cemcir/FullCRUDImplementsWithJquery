using FullCRUDImplementationWithJquery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Core.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);

        AccessToken RemoveToken();
    }
}
