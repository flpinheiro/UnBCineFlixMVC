using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Compania
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Funcao Identificacao
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Funcao Nome
        /// </summary>
        [Required, MaxLength(100), Display(Name = "Company Name")]
        public string Name { get; set; }
        /// <summary>
        /// Funcao CNPJ
        /// </summary>
        [MaxLength(20), Display(Name = "Company CNPJ")]
        public string CNPJ { get; set; }
        /// <summary>
        /// Funcao URL
        /// </summary>
        [MaxLength(255), Display(Name = "Company URL")]
        public string Url { get; set; }

        /// <summary>
        /// Ligação externa <see cref="AddressCompany"/>
        /// </summary>
        public IList<AddressCompany> Addresses { get; set; }
        //public IList<Phone> Phones { get; set; }
    }
}
