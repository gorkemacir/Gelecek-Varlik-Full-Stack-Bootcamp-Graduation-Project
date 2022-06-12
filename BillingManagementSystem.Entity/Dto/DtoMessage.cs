using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Entity.Dto
{
    public class DtoMessage : DtoBase
    {
        public int MessageId { get; set; }
        public string MessageUser { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageTime { get; set; }
    }
}
