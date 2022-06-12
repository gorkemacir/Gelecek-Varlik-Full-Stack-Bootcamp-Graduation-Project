using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BillingManagementSystem.Entity.Models
{
    public partial class Apartment : EntityBase
    {
        public Apartment()
        {
            Users = new HashSet<User>();
        }

        public int ApartmentId { get; set; }
        public string ApartmentBlock { get; set; }
        public string ApartmentCase { get; set; }
        public string ApartmentType { get; set; }
        public string ApartmentFloor { get; set; }
        public string ApartmentNumber { get; set; }
        public string ApartmentOwner { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
