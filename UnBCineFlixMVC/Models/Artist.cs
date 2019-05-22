using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public string Country { get; set; }

        public IList<ArtistMovie> Movies { get; set; }
        public Artist()
        {
            Movies = new List<ArtistMovie>();
        }
    }
}
