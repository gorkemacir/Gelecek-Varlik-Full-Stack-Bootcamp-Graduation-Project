using BillingManagementSystem.Dal.Abstract;
using BillingManagementSystem.Entity.Dto;
using BillingManagementSystem.Entity.Models;
using BillingManagementSystem.Interface;
using BillingManagementSystem.Entity.IBase;
using BillingManagementSystem.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Bll
{
    public class ApartmentManager : GenericManager<Apartment, DtoApartment>, IApartmentService
    {
        public readonly IApartmentRepository apartmentRepository;
        public ApartmentManager(IServiceProvider service) : base(service)
        {
            apartmentRepository = service.GetService<IApartmentRepository>();
        }


    }
}