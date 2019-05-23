using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class MovieTheater
    {
        public int Id { get; set; }
        [Required]
        public int QtdRow { get; set; }
        [Required]
        public int QtdCol { get; set; }


        public int AddressCompanyId { get; set; }
        public AddressCompany AddressCompany { get; set; }

        public IList<Chair> Chairs { get; set; }

        public MovieTheater()
        {
            Chairs = new List<Chair>();
        }


    }
}
