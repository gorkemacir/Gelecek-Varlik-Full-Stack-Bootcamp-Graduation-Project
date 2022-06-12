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
    public class UserController : ApiBaseController<IUserService, User, DtoUser>
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) : base(userService)
        {
            this.userService = userService;
        }

        [HttpPost("Add")]
        public IResponse<DtoUser> Add(DtoUser entity)
        {
            try
            {
                return userService.Add(entity);
            }
            catch (Exception ex)
            {

                return new Response<DtoUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
        [HttpPut("Update")]
        public IResponse<DtoUser> Update(DtoUser entity)
        {
            try
            {
                return userService.Update(entity);
            }
            catch (Exception ex)
            {

                return new Response<DtoUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
        [HttpGet("GetAll")]
        public IResponse<List<DtoUser>> GetAll()
        {
            try
            {
                return userService.GetAll();
            }
            catch (Exception ex)
            {

                return new Response<List<DtoUser>>
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
                return userService.DeleteById(id);
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
        [HttpGet("FindBillElectric")]
        public IResponse<List<DtoUser>> Find(int BillElectric)
        {
            try
            {
                return userService.Find(BillElectric);
             
            }
            catch (Exception ex)
            {
                return new Response<List<DtoUser>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
       
    }
}
