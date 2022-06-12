using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BillingManagementSystem.Entity.Models
{
    public partial class Message : EntityBase
    {
        public int MessageId { get; set; }
        public string MessageUser { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageTime { get; set; }
    }
}
