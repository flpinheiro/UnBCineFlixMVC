using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required, MaxLength(100), Display(Name = "Movie Title")]
        public string Title { get; set; }
        [Display(Name = "Movie Duration")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int Duration { get; set; }
        [Display(Name = "Release Date"),DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Movie Synopsis")]
        public string Synopsis { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Movie Poster")]
        public byte[] Poster { get; set; }
        [Url, Display(Name = "Movie Trailer")]
        public byte[] Trailer { get; set; }

        /// <summary>
        /// Chave estrangeira do banco de dados <see cref="Rating"/>
        /// </summary>
        public int? RatingId { get; set; }
        public Rating Rating { get; set; }

        /// <summary>
        /// Ligação externa com banco de dados <see cref="Session"/>, <see cref="Artist"/> e <seealso cref="GenreMovie"/>
        /// </summary>
        public IList<Session> Sessions { get; set; }
        public IList<ArtistMovie> Artists { get; set; }
        public IList<GenreMovie> GenreMovies { get; set; }

        public Movie()
        {
            Artists = new List<ArtistMovie>();
            Sessions = new List<Session>();
            GenreMovies = new List<GenreMovie>();
        }
        public string DurationToString()
        {
            return $"{Duration/60}h{Duration%60}";
        }
    }
}
