using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Required, MaxLength(100), Display(Name= "Movie Rating")]
        public string Name { get; set; }
        [Required , Display(Name = "Minimum Age Required")]
        public int Age { get; set; }
        /// <summary>
        /// ligação externa com o banco de dados <see cref="Movie"/>
        /// </summary>
        public IList<Movie> Movies { get; set; }
        public Rating()
        {
            Movies = new List<Movie>();
        }
    }
}
