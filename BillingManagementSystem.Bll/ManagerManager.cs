﻿using BillingManagementSystem.Dal.Abstract;
using BillingManagementSystem.Entity.Dto;
using BillingManagementSystem.Entity.Models;
using BillingManagementSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Bll
{
    public class ManagerManager : GenericManager<Manager, DtoManager>, IManagerService
    {
        public readonly IManagerRepository managerRepository;
        public ManagerManager(IServiceProvider service) : base(service)
        {
            managerRepository = service.GetService< IManagerRepository >();
        }

    }
}
