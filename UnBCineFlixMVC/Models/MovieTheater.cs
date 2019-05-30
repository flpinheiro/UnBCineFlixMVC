using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class MovieTheater
    {
        //public int Id { get; set; }
        public int MovieTheaterNumber { get; set; }
        [Required]
        public int QtdRow { get; set; }
        [Required]
        public int QtdCol { get; set; }

        /// <summary>
        /// Chave estrangeira do banco de dados <see cref="AddressCompany"/>
        /// </summary>
        public int AddressCompanyId { get; set; }
        public AddressCompany AddressCompany { get; set; }

        /// <summary>
        /// Ligação externa do banco de dados <see cref="Chair"/> e <see cref="Session"/>
        /// </summary>
        private Chair[][] _arrayChair;
        public IList<Chair> Chairs { get; set; }
        public IList<Session> Sessions { get; set; }

        public MovieTheater()
        {
            //QtdRow = qtdRow;
            //QtdCol = qtdCol;
            Chairs = new List<Chair>();
            Sessions = new List<Session>();
        }
        public void AddChair(int row, int col)
        {
            AddChair(new Chair(row, col));
        }
        public void AddChair(Chair chair)
        {
            if (_arrayChair == null)
            {
                InitArrayChair();
            }
            if (_arrayChair[chair.Row][chair.Col] == null)
            {
                _arrayChair[chair.Row][chair.Col] = chair;
            }
            else
            {
                throw new Exception("Já existe essa cadeira.");
            }
        }
        private void InitArrayChair()
        {
            for (int i = 0; i < QtdRow; i++)
            {
                _arrayChair = new Chair[QtdRow][];
                for (int j = 0; j < QtdCol; j++)
                {
                    _arrayChair[i] = new Chair[QtdCol];
                }
            }
        }
    }
}
