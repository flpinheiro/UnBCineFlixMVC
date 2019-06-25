using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Define o endereço de uma Empresa
    /// </summary>
    public class AddressCompany: Address
    {
        /// <summary>
        /// Chave estrageira do banco de Dados referência <see cref="Company"/>
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Funcao Compania
        /// </summary>
        public Company Company { get; set; }
        /// <summary>
        /// Funcao Nome
        /// </summary>
        [Required,MaxLength(100), Display(Name = "Company Name")]
        public string Name { get; set; }
        /// <summary>
        /// Conjunto de Ligações externas
        /// <see cref="Phone"/> e <see cref="MovieTheater"/>
        /// </summary>
        public IList<Phone> Phones { get; set; }
        /// <summary>
        /// Funcao Cinema
        /// </summary>
        public IList<MovieTheater> MovieTheaters { get; set; }

        /// <summary>
        /// Funcao Endereco da Compania
        /// </summary>
        public AddressCompany()
        {
            Phones = new List<Phone>();
            MovieTheaters = new List<MovieTheater>();
        }
    }
}
