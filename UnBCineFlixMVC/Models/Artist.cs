using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Artista
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Funcao Identificacao
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Funcao Nome
        /// </summary>
        [Required,Display(Name = "Artist Name"), MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Funcao Aniversario
        /// </summary>
        [DataType(DataType.Date),Display(Name = "Artist Birthday")]
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Funcao Pais
        /// </summary>
        [Display(Name = "Artist Country"), MaxLength(100)]
        public string Country { get; set; }

        /// <summary>
        /// Lista de ligações externas <see cref="Movie"/> e <seealso cref="ArtistMovie"/>
        /// </summary>
        public IList<ArtistMovie> Movies { get; set; }
        /// <summary>
        /// Funcao Artista
        /// </summary>
        public Artist()
        {
            Movies = new List<ArtistMovie>();
        }
    }
}
