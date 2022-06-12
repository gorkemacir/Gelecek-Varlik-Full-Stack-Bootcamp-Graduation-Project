using BillingManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Dal.Abstract
{
    public interface IUserRepository
    {
        User Login(User login);
    }
}
