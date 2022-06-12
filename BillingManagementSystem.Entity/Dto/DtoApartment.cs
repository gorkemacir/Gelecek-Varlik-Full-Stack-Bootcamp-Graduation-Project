using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Entity.Dto
{
    public class DtoApartment : DtoBase
    {
        public DtoApartment()
        {
           
        }
        public int ApartmentId { get; set; }
        public string ApartmentBlock { get; set; }
        public string ApartmentCase { get; set; }
        public string ApartmentType { get; set; }
        public string ApartmentFloor { get; set; }
        public string ApartmentNumber { get; set; }
        public string ApartmentOwner { get; set; }
    }
}
