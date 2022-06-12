using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Entity.Dto
{
    public class DtoManager : DtoBase
    {
            public int ManagerId { get; set; }
            public string ManagerMail { get; set; }
            public string ManagerPassword { get; set; }     
    }
}
