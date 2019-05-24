using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name = "Artist Name"), MaxLength(100)]
        public string Name { get; set; }
        [DataType(DataType.Date),Display(Name = "Artist Birthday")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Artist Country"), MaxLength(100)]
        public string Country { get; set; }

        /// <summary>
        /// Lista de ligações externas <see cref="Movie"/> e <seealso cref="ArtistMovie"/>
        /// </summary>
        public IList<ArtistMovie> Movies { get; set; }
        public Artist()
        {
            Movies = new List<ArtistMovie>();
        }
    }
}
