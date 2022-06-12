using BillingManagementSystem.Entity.Base;
using BillingManagementSystem.Entity.Dto;
using BillingManagementSystem.Entity.IBase;
using BillingManagementSystem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService userService;
        public UserLoginController(IUserLoginService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IResponse<DtoUserToken> Login(DtoLogin login)
        {
            try
            {
                return userService.Login(login);
            }
            catch (Exception ex)
            {

                return new Response<DtoUserToken>()
                {
                    Message = "Error" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null

                };
            }
        }
    }
}
