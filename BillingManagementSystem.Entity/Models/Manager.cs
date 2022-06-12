using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BillingManagementSystem.Entity.Models
{
    public partial class Manager : EntityBase
    {
        public int ManagerId { get; set; }
        public string ManagerMail { get; set; }
        public string ManagerPassword { get; set; }
    }
}
