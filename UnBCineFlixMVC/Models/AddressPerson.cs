using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Endereco Pessoal
    /// </summary>
    public class AddressPerson : Address
    {
        /// <summary>
        /// Chave estrangeira do banco de dados referecia <see cref="Person"/>
        /// </summary>
        public int PersonId { get; set; }
        /// <summary>
        /// Funcao Pessoa
        /// </summary>
        public Person Person { get; set; }
    }
}
