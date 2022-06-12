using BillingManagementSystem.Dal.Abstract;
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
    public class DebtManager : GenericManager<Debt, DtoDebt>, IDebtService
    {
        public readonly IDebtRepository debtRepository;
        public DebtManager(IServiceProvider service) : base(service)
        {
            debtRepository = service.GetService<IDebtRepository>();
        }
    
    }
}
