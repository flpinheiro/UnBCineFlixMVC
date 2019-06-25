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
        /// <summary>
        /// Funcao Identificacao do Genero
        /// </summary>
        public int GenreId { get; set; }
        /// <summary>
        /// Funcao Genero
        /// </summary>
        public Genre Genre { get; set; }
        /// <summary>
        /// Funcao Identificacao Filme
        /// </summary>
        public int MovieId { get; set; }
        /// <summary>
        /// Identificacao Filme
        /// </summary>
        public Movie Movie { get; set; }

    }
}
