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
        public int Id { get; set; }

        [Required, MaxLength(100), MinLength(2)]
        public string Country { get; set; }
        [Required, MaxLength(100), MinLength(2)]
        public string State { get; set; }
        [Required, MaxLength(100), MinLength(2)]
        public string City { get; set; }
        [Required, MaxLength(100), MinLength(2)]
        public string District { get; set; }
        [Required, MaxLength(100), MinLength(2)]
        public string Street { get; set; }
        private int _number;
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
        /// 
        /// </summary>
        [MaxLength(255)]
        public string Complement { get; set; }

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
