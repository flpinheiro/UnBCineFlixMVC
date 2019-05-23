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
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Synopsis { get; set; }
        [DataType(DataType.ImageUrl)]
        public byte[] Poster { get; set; }
        [Url]
        public byte[] Trailer { get; set; }

        
        public int? RatingId { get; set; }
        //[ForeignKey("RatingId")]
        public Rating Rating { get; set; }

        public IList<ArtistMovie> Artists { get; set; }
        //public IList<RatingMovie> Ratings { get; set; }

        public Movie()
        {
            Artists = new List<ArtistMovie>();
            //Ratings = new List<RatingMovie>();
        }
    }
}
