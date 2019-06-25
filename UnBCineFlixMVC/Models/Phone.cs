using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Telefone
    /// </summary>
    public class Phone
    {
        /// <summary>
        /// Funcao Identificacao
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Funcao Codigo do Pais
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int CountryCode { get; set; }
        /// <summary>
        /// Funcao DDD
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int AreaCode { get; set; }
        /// <summary>
        /// Funcao Numero
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int Number { get; set; }

        /// <summary>
        /// Chave estrangeira do banco de dados <see cref="Person"/>
        /// </summary>
        public int? PersonId { get; set; }
        /// <summary>
        /// Funcao Telefone estrangeiro
        /// </summary>
        public Person Person { get; set; }
        /// <summary>
        /// Chave estrangeira do banco de dados <see cref="AddressCompany"/>
        /// </summary>
        public int? AddressCompanyId { get; set; }
        /// <summary>
        /// Funcao Endereco da Compania
        /// </summary>
        public AddressCompany AddressCompany { get; set; }
    }
}
