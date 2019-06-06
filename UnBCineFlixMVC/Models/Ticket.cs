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
        [Required, DataType(DataType.Currency),Display(Name = "Ticket Value Paid")]
        public decimal Value { get; set; }
//        [Display(Name = "Session Hour")]
//        public DateTime SessionTime { get; set; }//pk,fk
//        public int MovieTheaterNumber { get; set; }//pk,fk
//        public int AddressCompanyId { get; set; }//pk,fk
        public int ChairCol { get; set; }//pk
        public int ChairRow { get; set; }//pk

        public int SessionId { get; set; }
        public Session Session { get; set; }
        //public Chair Chair { get; set; }

    }
}
