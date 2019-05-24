using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe de ligação n para n <see cref="Artist"/> e <see cref="Movie"/>
    /// </summary>
    public class ArtistMovie
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
