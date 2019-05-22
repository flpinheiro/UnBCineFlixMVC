using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Artist Name")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Artist Birthday")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Artist Country")]
        public string Country { get; set; }

        public IList<ArtistMovie> Movies { get; set; }
        public Artist()
        {
            Movies = new List<ArtistMovie>();
        }
    }
}
