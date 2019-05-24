using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Employee : Person
    {
        /// <summary>
        /// matricula de funcionario
        /// </summary>
        [Required,StringLength(10)]
        public int Cod { get; set; }

        /// <summary>
        /// Senha de funcionario
        /// </summary>
        [Required,DataType(DataType.Password),MinLength(6),MaxLength(100)]
        public string PassE { get; set; }
    }
}
