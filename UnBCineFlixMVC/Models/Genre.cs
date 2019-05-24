using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required, MaxLength(100), Display(Name = "Movie Genre")]
        public string Name { get; set; }

        /// <summary>
        /// Ligaçào externa do Banco de Dados <see cref="Genre"/> e <seealso cref="Movie"/>
        /// </summary>
        public IList<GenreMovie> GenreMovies { get; set; }
        public Genre()
        {
            GenreMovies = new List<GenreMovie>();
        }
    }
}
