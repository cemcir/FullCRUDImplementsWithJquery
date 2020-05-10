using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullCRUDImplementationWithJquery.API.Extensions;
using FullCRUDImplementationWithJquery.API.Models.Resource;
using FullCRUDImplementationWithJquery.Core.Responses;
using FullCRUDImplementationWithJquery.Core.Services;
using FullCRUDImplementationWithJquery.Core.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCRUDImplementationWithJquery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;

        public LoginsController(IAuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AccessToken(LoginResource loginResource)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else {
                BaseResponse<AccessToken> accessTokenResponse = this.authenticateService.CreateAccessToken(loginResource.UserName, loginResource.Password);

                if (accessTokenResponse.Success) {
                    return Ok(accessTokenResponse.Extra);
                }
                else {
                    return BadRequest(accessTokenResponse.ErrorMessageCode);
                }
            }
        }

        [HttpDelete]
        [Authorize]
        public IActionResult RemoveToken()
        {
            BaseResponse<AccessToken> accessTokenResponse = this.authenticateService.RemoveToken();
            return Ok(accessTokenResponse.Extra);
        }
    }
}