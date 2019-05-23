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
        //public int Id { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        public int Col { get; set; }
        [NotMapped]
        public bool Status { get; set; }

        public int MovieTheaterId { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public Ticket Ticket { get; set; }

        public Chair()
        {
            Status = false; // cadeira vazia
        }
        public Chair(int row, int col, bool status = false)
        {
            Row = row;
            Col = col;
            Status = status;
        }
    }
}
