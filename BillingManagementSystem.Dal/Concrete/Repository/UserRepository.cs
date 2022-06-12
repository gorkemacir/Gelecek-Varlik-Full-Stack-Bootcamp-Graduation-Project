using BillingManagementSystem.Dal.Abstract;
using BillingManagementSystem.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Dal.Concrete.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

        public User Login(User login)
        {
            var user = dbset.Where(x => x.UserMail == login.UserMail && x.UserPassword == login.UserPassword).SingleOrDefault();

            return user;
        }
    }
}