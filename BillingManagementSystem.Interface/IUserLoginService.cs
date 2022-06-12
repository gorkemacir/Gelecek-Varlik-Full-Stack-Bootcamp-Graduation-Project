using BillingManagementSystem.Entity.Dto;
using BillingManagementSystem.Entity.IBase;
using BillingManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Interface
{
    public interface IUserLoginService : IGenericService<User, DtoUser>
    {
        IResponse<DtoUserToken> Login(DtoLogin login);
        
    }
}
