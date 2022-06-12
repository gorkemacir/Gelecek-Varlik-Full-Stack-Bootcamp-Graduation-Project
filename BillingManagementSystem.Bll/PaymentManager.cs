using BillingManagementSystem.Dal.Abstract;
using BillingManagementSystem.Entity.Dto;
using BillingManagementSystem.Entity.IBase;
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
    public class PaymentManager : GenericManager<Payment, DtoPayment>, IPaymentService
    {
        public readonly IPaymentRepository paymentRepository;
        public PaymentManager(IServiceProvider service) : base(service)
        {
            paymentRepository = service.GetService<IPaymentRepository>();
        }

        IResponse<List<DtoPayment>> IPaymentService.Find(int PaymentAmount)
        {
            throw new NotImplementedException();
        }
    }
}