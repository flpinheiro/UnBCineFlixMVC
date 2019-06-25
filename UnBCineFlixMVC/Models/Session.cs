using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Sessao
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Funcao Identificacao
        /// </summary>
        public int Id { get; set; }//pk
        /// <summary>
        /// Funcao Identificacao do endereco da Compania
        /// </summary>
        public int? AddressCompanyId { get; set; }//fk
        /// <summary>
        /// Funcao Numero do cinema
        /// </summary>
        [Display(Name = "Movie Theater Number")]
        public int? MovieTheaterNumber { get; set; }//fk
        /// <summary>
        /// Funcao Cinema
        /// </summary>
        public MovieTheater MovieTheater { get; set; }
        /// <summary>
        /// Funcao Identificacao Filme
        /// </summary>
        public int MovieId { get; set; }
        /// <summary>
        /// Funcao Filme
        /// </summary>
        public Movie Movie { get; set; }
        /// <summary>
        /// Funcao Horario da Sessao
        /// </summary>
        [Display(Name = "Session Time"), DataType(DataType.DateTime)]
        public DateTime SessionTime { get; set; }//pk
        /// <summary>
        /// Ligação externa com o banco de dados <see cref="Ticket"/>
        /// </summary>
        public IList<Ticket> Tickets { get; set; }
        /// <summary>
        /// Funcao Sessao
        /// </summary>
        public Session()
        {
            Tickets = new List<Ticket>();
        }
        /// <summary>
        /// Funcao Sessao
        /// </summary>
        /// <param name="session"></param>
        public Session(Session session)
            : this()
        {
            Id = session.Id;
            AddressCompanyId = session.AddressCompanyId;
            MovieTheaterNumber = session.MovieTheaterNumber;
            MovieTheater = new MovieTheater(session.MovieTheater);
            MovieId = session.MovieId;
            Movie = session.Movie;
            SessionTime = session.SessionTime;
            Tickets = session.Tickets;
            MovieTheater.CheckChairs(session.Tickets);
        }
        /// <summary>
        /// Funcao Duracao
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        public string DurationToTime(int duration)
        {
            return $"{duration / 60}H{duration % 60,2}min";
        }

        //private void CheckTickets(Ticket ticket)
        //{
        //    if (!Tickets.Contains(ticket))
        //    {
        //        var chairs = MovieTheater.Chairs.Where(c => (c.Row == ticket.ChairRow && c.Col == ticket.ChairCol)).ToList();
        //        if (chairs == null) { throw new NullReferenceException("impossible to find the chair choose."); }
        //        foreach (var chair in chairs)
        //        {
        //            chair.Status = true;
        //        }
        //    }
        //}
    }
}
