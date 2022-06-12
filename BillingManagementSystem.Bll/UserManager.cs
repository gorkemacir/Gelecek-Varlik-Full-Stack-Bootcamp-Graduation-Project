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
    public class UserManager : GenericManager<User, DtoUser>, IUserService
    {
        public readonly IUserRepository userRepository;
        private IConfiguration configuration;
        public UserManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
            this.configuration = configuration;
        }

        public Response AddUser(DtoUser user)
        {
            throw new NotImplementedException();
        }

        IResponse<List<DtoUser>> IUserService.Find(int BillElectric)
        {
            throw new NotImplementedException();
        }
    }
}
