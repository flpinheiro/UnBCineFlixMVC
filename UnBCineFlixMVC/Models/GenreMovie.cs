using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe de relação n para n entre <see cref="Genre"/> e <seealso cref="Movie"/>
    /// </summary>
    public class GenreMovie
    {
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}
