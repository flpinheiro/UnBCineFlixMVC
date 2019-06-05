﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Define o endereço de uma Empresa
    /// </summary>
    public class AddressCompany
    {

        public int Id { get; set; }

        [Required, MaxLength(100), MinLength(2)]
        public String Name { get; set; }
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
        [Required]
        public int Number { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [MaxLength(255)]
        public string Complement { get; set; }

        /// <summary>
        /// Chave estrageira do banco de Dados referência <see cref="Company"/>
        /// </summary>
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        /// <summary>
        /// Conjunto de Ligações externas
        /// <see cref="Phone"/> e <see cref="MovieTheater"/>
        /// </summary>
        public IList<Phone> Phones { get; set; }
        public IList<MovieTheater> MovieTheaters { get; set; }

        public AddressCompany()
        {
            Phones = new List<Phone>();
            MovieTheaters = new List<MovieTheater>();
        }

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
