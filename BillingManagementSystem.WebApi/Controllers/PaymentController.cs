using BillingManagementSystem.Entity.Base;
using BillingManagementSystem.Entity.Dto;
using BillingManagementSystem.Entity.IBase;
using BillingManagementSystem.Entity.Models;
using BillingManagementSystem.Interface;
using BillingManagementSystem.WebApi.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ApiBaseController<IPaymentService, Payment, DtoPayment>
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService) : base(paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpGet("FindPayment")]
        public IResponse<List<DtoPayment>> Find(int PaymentAmount)
        {
            try
            {
                return paymentService.Find(PaymentAmount);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoPayment>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}