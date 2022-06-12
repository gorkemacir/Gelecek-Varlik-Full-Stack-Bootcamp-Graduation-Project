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
    public class ApartmentController : ApiBaseController<IApartmentService, Apartment, DtoApartment>
    {
        private readonly IApartmentService apartmentService;

        public ApartmentController(IApartmentService apartmentService) : base(apartmentService)
        {
            this.apartmentService = apartmentService;
        }
        [HttpPost("Add")]
        public IResponse<DtoApartment> Add(DtoApartment entity)
        {
            try
            {
                return apartmentService.Add(entity);
            }
            catch (Exception ex)
            {

                return new Response<DtoApartment>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
        [HttpPut("Update")]
        public IResponse<DtoApartment> Update(DtoApartment entity)
        {
            try
            {
                return apartmentService.Update(entity);
            }
            catch (Exception ex)
            {

                return new Response<DtoApartment>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
        [HttpGet("GetAll")]
        public IResponse<List<DtoApartment>> GetAll()
        {
            try
            {
                return apartmentService.GetAll();
            }
            catch (Exception ex)
            {

                return new Response<List<DtoApartment>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
        [HttpDelete("Delete")]
        public IResponse<bool> Delete(int id)
        {
            try
            {
                return apartmentService.DeleteById(id);
            }
            catch (Exception ex)
            {

                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = false
                };
            }
        }



    }
}
