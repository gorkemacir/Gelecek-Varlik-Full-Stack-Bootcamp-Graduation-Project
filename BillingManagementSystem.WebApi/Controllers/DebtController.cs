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
    public class DebtController : ApiBaseController<IDebtService, Debt, DtoDebt>
    {
        private readonly IDebtService debtService;

        public DebtController(IDebtService debtService) : base(debtService)
        {
            this.debtService = debtService;
        }

        [HttpGet("GetAll")]
        public IResponse<List<DtoDebt>> GetAll()
        {
            try
            {
                return debtService.GetAll();
            }
            catch (Exception ex)
            {

                return new Response<List<DtoDebt>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }


    }
}
