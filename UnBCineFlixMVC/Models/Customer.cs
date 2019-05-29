using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Customer : Person
    {
        [Required,MinLength(6),MaxLength(100), EmailAddress,Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required,DataType(DataType.Password),MinLength(6),MaxLength(100),Display(Name = "Password")]
        public string PassC { get; set; }
    }
}
