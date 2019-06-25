using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Cadeira
    /// </summary>
    public class Chair
    {
        private int _row;
        /// <summary>
        /// Funcao Linha
        /// </summary>
        [Required]
        [Range(0, int.MaxValue,ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int Row
        {
            get
            {
                return _row;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Row must be bigger than zero");
                else
                    _row = value;
            }
        }//pk
        private int _col;
        /// <summary>
        /// Funcao Coluna
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        public int Col
        {
            get
            {
                return _col;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Col must be bigger than zero");
                else
                    _col = value;
            }
        }//pk
        /// <summary>
        /// Define se a cadeira está vendida = true ou está disponivel para venda = false
        /// </summary>
        [NotMapped]
        public bool Status { get; set; }
        /// <summary>
        /// Funcao Identificacao do endereco das companias
        /// </summary>
        public int AddressCompanyId { get; set; }//fk,pk
        /// <summary>
        /// Funcao Numero do Cinema
        /// </summary>
        public int MovieTheaterNumber { get; set; }//fk,pk
        /// <summary>
        /// LIgação externa com o banco de dados <see cref="MovieTheater"/>
        /// </summary>
        //public int MovieTheaterId { get; set; }
        public MovieTheater MovieTheater { get; set; }
        //public IList<Ticket> Tickets { get; set; }
        /// <summary>
        /// Funcao cadeira
        /// </summary>
        public Chair()
        {
            Status = false; // cadeira vazia
            //Tickets = new List<Ticket>();
        }
        /// <summary>
        /// Matriz Cadeira
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="status"></param>
        public Chair(int row, int col, bool status = false)
        {
            Row = row;
            Col = col;
            Status = status;
        }
        /// <summary>
        /// String Cadeira
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Status.ToString();
        }
    }
}
