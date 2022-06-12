using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BillingManagementSystem.Entity.Models
{
    public partial class Debt : EntityBase
    {
        public Debt()
        {
            Users = new HashSet<User>();
        }

        public int DebtId { get; set; }
        public int DebtAmount { get; set; }
        public int PaymentId { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
