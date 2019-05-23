using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlixMVC.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required, DataType(DataType.Currency),Display(Name = "Valor")]
        public Decimal Value { get; set; }
        //public int SessionId { get; set; }

    }
}
