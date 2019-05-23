using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnBCineFlix.Models
{
    public class AddressCompany
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
        [MaxLength(255)]
        public string Complement { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public IList<Phone> Phones { get; set; }
    }
}
