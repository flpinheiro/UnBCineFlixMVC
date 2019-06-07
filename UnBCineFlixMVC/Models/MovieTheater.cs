using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    public class MovieTheater
    {
        //public int Id { get; set; }

        private int _number;
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        [Display(Name = "Movie Theater Number")]
        public int MovieTheaterNumber
        {
            get
            {
                return _number;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("The number of the movie Theater must be bigger than zero");
                else
                    _number = value;
            }

        }
        private int _row;
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        [Display(Name = "Maximum quantities of Rows")]
        public int QtdRow
        {
            get
            {
                return _row;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("The Quantity of Rows must be bigger than zero");
                else
                    _row = value;
            }
        }
        private int _col;
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than zero.")]
        [Display(Name = "Maximum quantities of Columns")]
        public int QtdCol
        {
            get
            {
                return _col;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("The quantity of Columns must must be bigger than zero");
                else
                    _col = value;
            }
        }

        /// <summary>
        /// Chave estrangeira do banco de dados <see cref="AddressCompany"/>
        /// </summary>
        public int AddressCompanyId { get; set; }
        public AddressCompany AddressCompany { get; set; }

        /// <summary>
        /// Ligação externa do banco de dados <see cref="Chair"/> e <see cref="Session"/>
        /// </summary>
        [NotMapped]
        private Chair[][] _arrayChair;
        public Chair GetArrayChair(int row, int col)
        {
            return _arrayChair[row][col];
        } 
        public IList<Chair> Chairs { get; set; }
        public IList<Session> Sessions { get; set; }

        public MovieTheater()
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
            AddressCompanyId = movieTheater.AddressCompanyId;
            AddressCompany = movieTheater.AddressCompany;
            Chairs = movieTheater.Chairs;
            MovieTheaterNumber = movieTheater.MovieTheaterNumber;
            Sessions = movieTheater.Sessions;
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
        /// Adiciona uma cadeira ao MovieTheater
        /// </summary>
        /// <param name="chair">Recebe UM Chair</param>
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
                throw new DbUpdateException($"Chair ({chair.Row},{chair.Col}) already exist, Try another", new ArgumentException());
            }
        }
    }
}
