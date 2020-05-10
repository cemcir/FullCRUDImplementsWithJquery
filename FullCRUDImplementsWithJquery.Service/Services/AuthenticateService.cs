using FullCRUDImplementationWithJquery.Core.Entities;
using FullCRUDImplementationWithJquery.Core.Responses;
using FullCRUDImplementationWithJquery.Core.Services;
using FullCRUDImplementationWithJquery.Core.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullCRUDImplementationWithJquery.Service.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserService userService;
        private readonly ITokenHandler tokenHandler;

        public AuthenticateService(IUserService userService,ITokenHandler tokenHandler) {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        public BaseResponse<AccessToken> CreateAccessToken(string email, string password)
        {
            BaseResponse<User> userResponse = this.userService.FindByUserNameAndPassword(email, password);
            if (userResponse.Success)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.Extra);
                return new BaseResponse<AccessToken>(accessToken);
            }
            else {
                return new BaseResponse<AccessToken>(userResponse.ErrorMessageCode);
            }
        }

        public BaseResponse<AccessToken> RemoveToken()
        {
            try {
                AccessToken accessToken = this.tokenHandler.RemoveToken();
                return new BaseResponse<AccessToken>(accessToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
