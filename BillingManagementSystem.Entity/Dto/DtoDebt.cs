using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Entity.Dto
{
    public class DtoDebt : DtoBase
    {
        public DtoDebt()
        {
            
        }

        public int DebtId { get; set; }
        public int DebtAmount { get; set; }
        public int PaymentId { get; set; }
    }
}
