using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        [Required,Display(Name = "First Name"),MaxLength(100)]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name"),MaxLength(100)]
        public string LastName { get; set; }
        [DataType(DataType.Date),Display(Name = "Birthday")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "CPF"), MaxLength(20)]
        public string CPF { get; set; }
        /// <summary>
        /// Ligação externa com o banco de dados <see cref="Address"/> e <see cref="Phone"/>
        /// </summary>
        public IList<Address> Addresses { get; set; }
        public IList<Phone> Phones { get; set; }
    }
}
