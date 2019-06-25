using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Pessoa
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Funcao Identificacao
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Funcao Primero Nome
        /// </summary>
        [Required,Display(Name = "First Name"),MaxLength(100)]
        public string FirstName { get; set; }
        /// <summary>
        /// Funcao Ultimo nome
        /// </summary>
        [Required, Display(Name = "Last Name"),MaxLength(100)]
        public string LastName { get; set; }
        /// <summary>
        /// Funcao Aniversario
        /// </summary>
        [DataType(DataType.Date),Display(Name = "Birthday")]
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Funcao CPF
        /// </summary>
        
        [Display(Name = "CPF"), MaxLength(20),RegularExpression("[0-9]{3}[.]?[0-9]{3}[.]?[0-9]{3}[-]?[0-9]{2}", ErrorMessage="CPF must be like 000.000.000-00")]
        public string CPF { get; set; }
        /// <summary>
        /// Ligação externa com o banco de dados <see cref="Address"/> e <see cref="Phone"/>
        /// </summary>
        public IList<AddressPerson> Addresses { get; set; }
        /// <summary>
        /// Funcao Telefone
        /// </summary>
        public IList<Phone> Phones { get; set; }
    }
}
