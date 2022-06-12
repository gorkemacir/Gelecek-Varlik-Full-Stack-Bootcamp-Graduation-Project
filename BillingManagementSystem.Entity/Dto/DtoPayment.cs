using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Entity.Dto
{
    public class DtoPayment : DtoBase
    {
        public DtoPayment()
        {
         
        }

        public int PaymentId { get; set; }
        public int PaymentAmount { get; set; }
        public string PaymentFullname { get; set; }
        public string PaymentCardnumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentCvv { get; set; }
        public int PaymentBalance { get; set; }
    }
}
