using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Entity.Dto
{
    public class DtoUser : DtoBase
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
    }
}
