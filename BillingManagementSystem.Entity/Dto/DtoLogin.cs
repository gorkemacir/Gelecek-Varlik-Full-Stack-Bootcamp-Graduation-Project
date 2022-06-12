using BillingManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingManagementSystem.Entity.Dto
{
    public class DtoLogin : DtoBase
    {
        [Required]
        [StringLength(maximumLength: 40)]
        [DataType(DataType.Text)]
        public string UserCode { get; set; }

        [Required]
        [StringLength(maximumLength: 12)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
