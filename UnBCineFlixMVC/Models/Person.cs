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
        
        [Display(Name = "CPF"), MaxLength(20),RegularExpression("[0-9]{3}[.]?[0-9]{3}[.]?[0-9]{3}[-]?[0-9]{2}", ErrorMessage="CPF must be like 000.000.000-00")]
        public string CPF { get; set; }
        /// <summary>
        /// Ligação externa com o banco de dados <see cref="Address"/> e <see cref="Phone"/>
        /// </summary>
        public IList<AddressPerson> Addresses { get; set; }
        public IList<Phone> Phones { get; set; }
    }
}
