using BillingManagementSystem.Entity.Base;
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
    public interface IUserService : IGenericService<User,DtoUser>
    {
        Response AddUser(DtoUser user);
        IResponse<List<DtoUser>> Find(int BillElectric);
       
    }
}
