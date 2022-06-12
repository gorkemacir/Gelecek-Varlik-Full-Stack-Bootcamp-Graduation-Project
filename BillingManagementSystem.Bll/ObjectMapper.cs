using AutoMapper;
using BillingManagementSystem.Entity.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Bll
{
    internal class ObjectMapper
    {//lazy yapısını oluşturuyoruz

        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            return config.CreateMapper();
        }
        );
        public static IMapper Mapper => lazy.Value;
    }
}
