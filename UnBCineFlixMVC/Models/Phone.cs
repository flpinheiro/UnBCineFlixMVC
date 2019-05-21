using System;
using System.Collections.Generic;
using System.Text;

namespace UnBCineFlix.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
