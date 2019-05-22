using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }

        public IList<Address> Addresses { get; set; }
        public IList<Phone> Phones { get; set; }
    }
}
