using BillingManagementSystem.Dal.Abstract;
using BillingManagementSystem.Entity.Base;
using BillingManagementSystem.Entity.Dto;
using BillingManagementSystem.Entity.IBase;
using BillingManagementSystem.Entity.Models;
using BillingManagementSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BillingManagementSystem.Bll
{
    public class UserLoginManager : GenericManager<User, DtoUser>, IUserLoginService
    {
        public readonly IUserRepository userRepository;
        private IConfiguration configuration;
        public UserLoginManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoUserToken> Login(DtoLogin login)
        {
            var user = userRepository.Login(ObjectMapper.Mapper.Map<User>(login));

            if (user != null)
            {

                var dtouser = ObjectMapper.Mapper.Map<DtoLoginUser>(user);

                var token = new TokenManager(configuration).CreateAccessToken(dtouser);

                var userToken = new DtoUserToken()
                {
                    DtoLoginUser = dtouser,
                    AccessToken = token
                };

                return new Response<DtoUserToken>
                {
                    Message = "Token üretildi",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };

            }
            else
            {
                return new Response<DtoUserToken>
                {
                    Message = "Mailiniz veya parolanız yanlış!",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }

    }
}
