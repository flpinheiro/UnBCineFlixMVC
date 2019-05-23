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
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public IList<GenreMovie> GenreMovies { get; set; }
        public Genre()
        {
            GenreMovies = new List<GenreMovie>();
        }
    }
}
