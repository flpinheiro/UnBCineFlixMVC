using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        [Required]
        public int Number { get; set; }

        /// <summary>
        /// Chave estrangeira do banco de dados <see cref="Person"/>
        /// </summary>
        public int? PersonId { get; set; }
        public Person Person { get; set; }
        /// <summary>
        /// Chave estrangeira do banco de dados <see cref="AddressCompany"/>
        /// </summary>
        public int? AddressCompanyId { get; set; }
        public AddressCompany AddressCompany { get; set; }
    }
}
