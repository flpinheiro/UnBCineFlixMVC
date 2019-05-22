using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class ArtistMovie
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
