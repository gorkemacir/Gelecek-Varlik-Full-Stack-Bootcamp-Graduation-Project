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
    public interface IPaymentService : IGenericService<Payment, DtoPayment>
    {
        IResponse<List<DtoPayment>> Find(int PaymentAmount);
    }
}
