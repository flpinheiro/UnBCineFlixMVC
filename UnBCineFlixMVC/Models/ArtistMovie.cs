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
        /// <summary>
        /// Funcao Identificacao do Artista
        /// </summary>
        public int ArtistId { get; set; }
        /// <summary>
        /// Funcao Artista
        /// </summary>
        public Artist Artist { get; set; }
        /// <summary>
        /// Funcao Identificacao Filmes
        /// </summary>
        public int MovieId { get; set; }
        /// <summary>
        /// Funcao Filme
        /// </summary>
        public Movie Movie { get; set; }
    }
}
