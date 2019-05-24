using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Session
    {
        public int MovieTheaterId { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Display(Name = "Session Time")]
        public DateTime SessionTime { get; set; }
        /// <summary>
        /// Ligação externa com o banco de dados <see cref="Ticket"/>
        /// </summary>
        public IList<Ticket> Tickets { get; set; }

        public Session()
        {
            Tickets = new List<Ticket>();
        }
    }
}
