using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Filme
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Funcao Identificacao
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Funcao Titulo
        /// </summary>
        [Required, MaxLength(100), Display(Name = "Movie Title")]
        public string Title { get; set; }
        /// <summary>
        /// Funcao Duracao
        /// </summary>
        [Display(Name = "Movie Duration")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int Duration { get; set; }
        /// <summary>
        /// Funcao Data de Lancamento
        /// </summary>
        [Display(Name = "Release Date"),DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// Funcao Sinopse
        /// </summary>
        [Display(Name = "Movie Synopsis")]
        public string Synopsis { get; set; }
        /// <summary>
        /// Funcao Poster
        /// </summary>
        [DataType(DataType.ImageUrl), Display(Name = "Movie Poster")]
        public byte[] Poster { get; set; }
        /// <summary>
        /// Funcao Trailer
        /// </summary>
        [Url, Display(Name = "Movie Trailer")]
        public byte[] Trailer { get; set; }

        /// <summary>
        /// Chave estrangeira do banco de dados <see cref="Rating"/>
        /// </summary>
        public int? RatingId { get; set; }
        /// <summary>
        /// Funcao Classificacao
        /// </summary>
        public Rating Rating { get; set; }

        /// <summary>
        /// Ligação externa com banco de dados <see cref="Session"/>, <see cref="Artist"/> e <seealso cref="GenreMovie"/>
        /// </summary>
        public IList<Session> Sessions { get; set; }
        /// <summary>
        /// Funcao Artistas
        /// </summary>
        public IList<ArtistMovie> Artists { get; set; }
        /// <summary>
        /// Funcao Genero dos Filmes
        /// </summary>
        public IList<GenreMovie> GenreMovies { get; set; }
        /// <summary>
        /// Funcao Filme
        /// </summary>
        public Movie()
        {
            Artists = new List<ArtistMovie>();
            Sessions = new List<Session>();
            GenreMovies = new List<GenreMovie>();
        }
        /// <summary>
        /// Funcao Duracao da string
        /// </summary>
        /// <returns></returns>
        public string DurationToString()
        {
            return $"{Duration/60}h{Duration%60}";
        }
    }
}
