using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlixMVC.Models
{
    public class Chair
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public bool Status { get; set; }

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
