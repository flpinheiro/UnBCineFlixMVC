using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class MovieTheater
    {
        //public int Id { get; set; }
        public int MovieTheaterNumber { get; set; }
        [Required]
        public int QtdRow { get; set; }
        [Required]
        public int QtdCol { get; set; }

        /// <summary>
        /// Chave estrangeira do banco de dados <see cref="AddressCompany"/>
        /// </summary>
        public int AddressCompanyId { get; set; }
        public AddressCompany AddressCompany { get; set; }

        /// <summary>
        /// Ligação externa do banco de dados <see cref="Chair"/> e <see cref="Session"/>
        /// </summary>
        public IList<Chair> Chairs { get; set; }
        public IList<Session> Sessions { get; set; }

        public MovieTheater()
        {
            Chairs = new List<Chair>();
            Sessions = new List<Session>();
        }
    }
}
