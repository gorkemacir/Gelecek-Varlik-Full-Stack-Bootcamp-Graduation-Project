using AutoMapper;
using BillingManagementSystem.Entity.Dto;
using BillingManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, DtoUser>().ReverseMap();
            CreateMap<Apartment, DtoApartment>().ReverseMap();
            CreateMap<Debt, DtoDebt>().ReverseMap();
            CreateMap<Message, DtoMessage>().ReverseMap();
            CreateMap<Payment, DtoPayment>().ReverseMap();
            CreateMap<User, DtoLoginUser>();
            CreateMap<DtoLogin, User>();           

        }
    }
}
