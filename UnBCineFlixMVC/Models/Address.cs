﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe endereco: define o endereço de uma pessoa.
    /// </summary>
    public class Address
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
        [Required]
        public int Number { get; set; }
        [Required]
        public int ZipCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(255)]
        public string Complement { get; set; }

        /// <summary>
        /// Chave estrangeira do banco de dados referecia <see cref="Person"/>
        /// </summary>
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
