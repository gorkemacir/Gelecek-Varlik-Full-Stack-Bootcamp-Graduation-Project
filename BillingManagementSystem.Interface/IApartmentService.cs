using BillingManagementSystem.Entity.Dto;
using BillingManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Interface
{
    public interface IApartmentService : IGenericService<Apartment,DtoApartment>
    {
        
    }
}
