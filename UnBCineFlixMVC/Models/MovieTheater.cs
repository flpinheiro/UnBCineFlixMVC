using Microsoft.EntityFrameworkCore;
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
        public Chair GetArrayChair(int row, int col)
        {
            return _arrayChair[row][col];
        } 
        public IList<Chair> Chairs { get; set; }
        public IList<Session> Sessions { get; set; }

        private MovieTheater()
        {
            Chairs = new List<Chair>();
            Sessions = new List<Session>();
        }
        public MovieTheater(int qtdRow, int qtdCol)
            : this()
        {
            QtdCol = qtdCol;
            QtdRow = qtdRow;
            _arrayChair = new Chair[qtdRow][];
            for (int i = 0; i < qtdRow; i++)
            {
                _arrayChair[i] = new Chair[qtdCol];
            }
        }
        public MovieTheater(MovieTheater movieTheater)
            : this(qtdRow: movieTheater.QtdRow, qtdCol: movieTheater.QtdCol)
        {
            foreach (var c in movieTheater.Chairs)
            {
                _arrayChair[c.Row][c.Col] = c;
            }
        }
        public void AddChair(int row, int col)
        {
            AddChair(new Chair(row, col));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chair"></param>
        /// <exception cref="ArgumentOutOfRangeException">Se a numeração da cadeira for maior do que o tamanho da sala essa exceção é lançada</exception>
        /// <exception cref="DbUpdateException">Caso a cadeira já exista no sistema a exceção é lançada.</exception>
        public void AddChair(Chair chair)
        {
            if (chair.Row >= QtdRow || chair.Col >= QtdCol)
            {
                throw new ArgumentOutOfRangeException("The chair numeration is bigger than the size of the MovieTheater");
            }

            if (_arrayChair[chair.Row][chair.Col] == null)
            {
                _arrayChair[chair.Row][chair.Col] = chair;
            }
            else
            {
                throw new DbUpdateException("Já existe essa cadeira.", new ArgumentException());
            }
        }

        //public void AddChair(IList<Chair> chairs)
        //{
        //    foreach (var c in chairs)
        //    {
        //        AddChair(c);
        //    }
        //}
    }
}
