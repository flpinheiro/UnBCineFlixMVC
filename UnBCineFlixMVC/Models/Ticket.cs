using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Ticket
    {
        //public int Id { get; set; }
        [Required, DataType(DataType.Currency),Display(Name = "Valor")]
        public Decimal Value { get; set; }

        public DateTime SessionTime { get; set; }
        public int MovieTheaterId { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }

        public Session Session { get; set; }
        public Chair Chair { get; set; }

    }
}
