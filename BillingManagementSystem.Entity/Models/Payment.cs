using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BillingManagementSystem.Entity.Models
{
    public partial class Payment : EntityBase
    {
        public Payment()
        {
            Debts = new HashSet<Debt>();
            Users = new HashSet<User>();
        }

        public int PaymentId { get; set; }
        public int PaymentAmount { get; set; }
        public string PaymentFullname { get; set; }
        public string PaymentCardnumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentCvv { get; set; }
        public int PaymentBalance { get; set; }

        public virtual ICollection<Debt> Debts { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
