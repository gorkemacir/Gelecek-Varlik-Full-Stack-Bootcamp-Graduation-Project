using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BillingManagementSystem.Entity.Models
{
    public partial class User : EntityBase
    {
        public int UserId { get; set; }
        public string UserFullname { get; set; }
        public string UserIdentity { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserTelephone { get; set; }
        public string UserCarinfo { get; set; }
        public int? BillElectric { get; set; }
        public int? BillNaturalgas { get; set; }
        public int? BillWater { get; set; }
        public int? SubscriptionAmount { get; set; }
        public int ApartmentId { get; set; }
        public int DebtId { get; set; }
        public int PaymentId { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual Debt Debt { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
