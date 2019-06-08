using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Session
    {
        public int Id { get; set; }//pk
        public int? AddressCompanyId { get; set; }//fk
        [Display(Name = "Movie Theater Number")]
        public int? MovieTheaterNumber { get; set; }//fk
        public MovieTheater MovieTheater { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Display(Name = "Session Time"), DataType(DataType.DateTime)]
        public DateTime SessionTime { get; set; }//pk
        /// <summary>
        /// Ligação externa com o banco de dados <see cref="Ticket"/>
        /// </summary>
        public IList<Ticket> Tickets { get; set; }

        public Session()
        {
            Tickets = new List<Ticket>();
        }
        public Session(Session session)
            :this()
        {
            Id = session.Id;
            AddressCompanyId = session.AddressCompanyId;
            MovieTheaterNumber = session.MovieTheaterNumber;
            MovieTheater = session.MovieTheater;
            MovieId = session.MovieId;
            Movie = session.Movie;
            SessionTime = session.SessionTime;
            Tickets = session.Tickets;
            foreach (var ticket in Tickets)
            {
               CheckTickets(ticket);
            }
        }
        public string DurationToTime(int duration)
        {
            return  $"{duration / 60}H{duration % 60}min";
        }

        private void CheckTickets(Ticket ticket)
        {
            if (!Tickets.Contains(ticket))
            {
                var chairs = MovieTheater.Chairs.Where(c=>(c.Row==ticket.ChairRow && c.Col == ticket.ChairCol)).ToList();
                if (chairs == null) { throw new NullReferenceException("impossible to find the chair choose."); }
                foreach (var chair in chairs)
                {
                    chair.Status = true;
                }
            }
        }
    }
}
