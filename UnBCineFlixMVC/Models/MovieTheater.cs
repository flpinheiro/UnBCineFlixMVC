using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnBCineFlix.Models
{
    /// <summary>
    /// Classe Cinema
    /// </summary>
    public class MovieTheater
    {
        //public int Id { get; set; }

        private int _number;
        /// <summary>
        /// Funcao Cinema
        /// </summary>
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
        /// <summary>
        /// Funcao Quantidade
        /// </summary>
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
        /// <summary>
        /// Funcao Quantidade
        /// </summary>
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

        /// <summary>
        /// Funcao Endereco da compania
        /// </summary>
        public AddressCompany AddressCompany { get; set; }

        /// <summary>
        /// Funcao Cadeira
        /// </summary>
        [NotMapped]
        private Chair[][] _arrayChair;
        /// <summary>
        /// Funcao Numero da Cadeira
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public Chair GetArrayChair(int row, int col)
        {
            return _arrayChair[row][col];
        }

        /// <summary>
        /// Funcao Sessao
        /// </summary>
        public IList<Session> Sessions { get; set; }
        /// <summary>
        /// Ligação externa do banco de dados <see cref="Chair"/>
        /// </summary>
        public IList<Chair> Chairs { get; set; }
        /// <summary>
        /// Funcao Cinema
        /// </summary>
        public MovieTheater()
        {
            Chairs = new List<Chair>();
            Sessions = new List<Session>();
        }
        /// <summary>
        /// Funcao Cinema
        /// </summary>
        /// <param name="qtdRow"></param>
        /// <param name="qtdCol"></param>
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
        /// <summary>
        /// Funcao Cinema
        /// </summary>
        /// <param name="movieTheater"></param>
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
        /// <summary>
        /// Funcao Adicionar Cadeira
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
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
        /// <summary>
        /// Funcao Checar Cadeiras
        /// </summary>
        /// <param name="tickets"></param>
        public void CheckChairs(IList<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                if (_arrayChair[ticket.ChairRow][ticket.ChairCol] != null)
                    _arrayChair[ticket.ChairRow][ticket.ChairCol].Status = true;
            }
        }
    }
}
