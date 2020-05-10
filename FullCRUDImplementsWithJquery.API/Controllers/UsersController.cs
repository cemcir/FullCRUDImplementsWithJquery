using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FullCRUDImplementationWithJquery.API.Models.Resource;
using FullCRUDImplementationWithJquery.Core.Entities;
using FullCRUDImplementationWithJquery.Core.Responses;
using FullCRUDImplementationWithJquery.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCRUDImplementationWithJquery.API.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetUser")]
        public IActionResult GetUser() {
            IEnumerable<Claim> claims = User.Claims;

            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;

            BaseResponse<User> userResponse = userService.GetById(int.Parse(userId));

            if (userResponse.Success) {
                return Ok(userResponse.Extra);
            }
            return BadRequest(userResponse.ErrorMessageCode);
        }

        /*
        [HttpPost("Authenticate")]
        public IActionResult FindByUserNameAndPassword(LoginResource userResource)
        {
            var response = this.userService.FindByUserNameAndPassword(userResource.UserName,userResource.Password);
            if (response.Success) {
                return Ok(response.Extra);
            }
            return BadRequest(response.ErrorMessageCode);
        }
        */
    }
}