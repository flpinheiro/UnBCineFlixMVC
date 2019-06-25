using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe endereco: define o endereço de uma pessoa.
    /// </summary>
    public abstract class Address
    {
        /// <summary>
        /// Identificacao
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Funcao Pais 
        /// </summary>
        [Required, MaxLength(100), MinLength(2)]
        public string Country { get; set; }
        /// <summary>
        /// Funcao Estado
        /// </summary>
        [Required, MaxLength(100), MinLength(2)]
        public string State { get; set; }
        /// <summary>
        /// Funcao Cidade
        /// </summary>
        [Required, MaxLength(100), MinLength(2)]
        public string City { get; set; }
        /// <summary>
        /// Funcao Distrito
        /// </summary>
        [Required, MaxLength(100), MinLength(2)]
        public string District { get; set; }
        /// <summary>
        /// Funcao Rua
        /// </summary>
        [Required, MaxLength(100), MinLength(2)]
        public string Street { get; set; }
        private int _number;
        /// <summary>
        /// Funcao Numero
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("The street number must be bigger than zero");
                else
                    _number = value;
            }

        }
        private int _zip;
        /// <summary>
        /// Funcao CEP
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int ZipCode
        {
            get
            {
                return _zip;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("The Zip code number must be bigger than zero");
                else
                    _zip = value;
            }

        }
        /// <summary>
        /// Funcao Complemento
        /// </summary>
        [MaxLength(255)]
        public string Complement { get; set; }

        /// <summary>
        /// Funcao String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var ret = new StringBuilder();
            ret.AppendLine($"Country: {Country}");
            ret.AppendLine($"City: {City}");
            ret.Append($"District: {District}");
            return base.ToString();
        }
    }
}
