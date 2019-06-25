using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Classificacao
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Funcao Identificacao da Classificacao
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Funcao Nome Classificacao
        /// </summary>
        [Required, MaxLength(100), Display(Name= "Movie Rating")]
        public string Name { get; set; }
        /// <summary>
        /// Funcao Idade Classificacao
        /// </summary>
        [Required , Display(Name = "Minimum Age Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int Age { get; set; }
        /// <summary>
        /// ligação externa com o banco de dados <see cref="Movie"/>
        /// </summary>
        public IList<Movie> Movies { get; set; }
        /// <summary>
        /// Funcao Classifcacao
        /// </summary>
        public Rating()
        {
            Movies = new List<Movie>();
        }
    }
}
