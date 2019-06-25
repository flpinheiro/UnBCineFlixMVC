using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Genero
    /// </summary>
    public class Genre 
    {
        /// <summary>
        /// Funcao Identificacao
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Funcao Nome Genero
        /// </summary>
        [Required, MaxLength(100), Display(Name = "Movie Genre")]
        public string Name { get; set; }

        /// <summary>
        /// Ligaçào externa do Banco de Dados <see cref="Genre"/> e <seealso cref="Movie"/>
        /// </summary>
        public IList<GenreMovie> GenreMovies { get; set; }
        /// <summary>
        /// Funcao Genero
        /// </summary>
        public Genre()
        {
            GenreMovies = new List<GenreMovie>();
        }
    }
}
