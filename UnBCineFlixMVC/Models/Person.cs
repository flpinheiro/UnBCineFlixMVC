using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public string CPF { get; set; }
        public IList<Address> Addresses { get; set; }
        public IList<Phone> Phones { get; set; }

    }
}
