using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Cliente
    /// </summary>
    public class Customer : Person
    {
        /// <summary>
        /// Funcao E-mail
        /// </summary>
        [Required,MinLength(6),MaxLength(100), EmailAddress,Display(Name = "E-mail")]
        public string Email { get; set; }
        /// <summary>
        /// Funcao Passe
        /// </summary>
        [Required,DataType(DataType.Password),MinLength(6),MaxLength(100),Display(Name = "Password")]
        public string PassC { get; set; }
    }
}
