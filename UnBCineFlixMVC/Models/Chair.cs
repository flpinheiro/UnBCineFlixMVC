using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Chair
    {
        private int _row;
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

        [NotMapped]
        public bool Status { get; set; }

        public int AddressCompanyId { get; set; }//fk,pk
        public int MovieTheaterNumber { get; set; }//fk,pk
        /// <summary>
        /// LIgação externa com o banco de dados <see cref="MovieTheater"/>
        /// </summary>
        //public int MovieTheaterId { get; set; }
        public MovieTheater MovieTheater { get; set; }
        //public IList<Ticket> Tickets { get; set; }

        public Chair()
        {
            Status = false; // cadeira vazia
            //Tickets = new List<Ticket>();
        }
        public Chair(int row, int col, bool status = false)
        {
            Row = row;
            Col = col;
            Status = status;
        }
        public override string ToString()
        {
            return Status.ToString();
        }
    }
}
