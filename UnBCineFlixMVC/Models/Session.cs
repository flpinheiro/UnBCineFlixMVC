using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Session
    {
        //public int Id { get; set; }
        public int MovieTheaterId { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
