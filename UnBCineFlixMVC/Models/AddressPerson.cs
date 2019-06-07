using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class AddressPerson : Address
    {
        /// <summary>
        /// Chave estrangeira do banco de dados referecia <see cref="Person"/>
        /// </summary>
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
