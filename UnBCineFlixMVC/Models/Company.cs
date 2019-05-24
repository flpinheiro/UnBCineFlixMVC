using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required, MaxLength(100), Display(Name = "Company Name")]
        public string Name { get; set; }
        [MaxLength(20), Display(Name = "Company CNPJ")]
        public string CNPJ { get; set; }
        [MaxLength(255), Display(Name = "Company URL")]
        public string Url { get; set; }

        /// <summary>
        /// Ligação externa <see cref="AddressCompany"/>
        /// </summary>
        public IList<AddressCompany> Addresses { get; set; }
        //public IList<Phone> Phones { get; set; }
    }
}
