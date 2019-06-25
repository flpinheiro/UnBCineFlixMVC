using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnBCineFlix.Models;

namespace UnBCineFlix.DAL
{
    /// <summary>
    /// Classe Funcao Contexto
    /// </summary>
    public class UnBCineFlixContext : DbContext
    {
        /// <summary>
        /// Funcao Endereco
        /// </summary>
        public DbSet<Address> Addresses { get; set; }
        /// <summary>
        /// FUncao Endereco da Compania
        /// </summary>
        public DbSet<AddressCompany> AddressCompanies { get; set; }
        /// <summary>
        /// Funcao Endereco pessoas
        /// </summary>
        public DbSet<AddressPerson> AddressPeople { get; set; }
        /// <summary>
        /// Funcao Artistas
        /// </summary>
        public DbSet<Artist> Artists { get; set; }
        /// <summary>
        /// Funcao Artistas de Filmes
        /// </summary>
        public DbSet<ArtistMovie> ArtistMovies { get; set; }
        /// <summary>
        /// Funcao Cadeiras
        /// </summary>
        public DbSet<Chair> Chairs { get; set; }
        /// <summary>
        /// Funcao Companias
        /// </summary>
        public DbSet<Company> Companies { get; set; }
        /// <summary>
        /// Funcao Clientes
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Funcao Empregados
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Funcao Generos
        /// </summary>
        //errorviemodel
        public DbSet<Genre> Genres { get; set; }
        /// <summary>
        /// Funcao Genero dos Filmes
        /// </summary>
        public DbSet<GenreMovie> GenreMovies { get; set; }
        /// <summary>
        /// Funcao Filmes
        /// </summary>
        public DbSet<Movie> Movies { get; set; }
        /// <summary>
        /// Funcao Cinema
        /// </summary>
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        /// <summary>
        /// Funcao Pessoas
        /// </summary>
        public DbSet<Person> People { get; set; }
        /// <summary>
        /// Funcao telefone
        /// </summary>
        public DbSet<Phone> Phones { get; set; }
        /// <summary>
        /// Funcao Ratings
        /// </summary>
        public DbSet<Rating> Ratings { get; set; }
        /// <summary>
        /// Funcao Sessao
        /// </summary>
        public DbSet<Session> Session { get; set; }
        /// <summary>
        /// Funcao Tickets
        /// </summary>
        public DbSet<Ticket> Tickets { get; set; }

        /// <summary>
        /// Funcao Contexto
        /// </summary>
        public UnBCineFlixContext()
        {
        }
        /// <summary>
        /// FUncao Opcao de Contexto
        /// </summary>
        /// <param name="option"></param>
        public UnBCineFlixContext(DbContextOptions<UnBCineFlixContext> option)
    : base(option)
        {
        }
        /// <summary>
        /// Funcao Criacao Modo 1
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Primary Key setup space
            #region pk
            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            //modelBuilder.Entity<AddressCompany>().HasKey(ac => ac.Id);
            //modelBuilder.Entity<AddressPerson>().HasKey(ap=>ap.Id);
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Phone>().HasKey(ph => ph.Id);
            modelBuilder.Entity<Rating>().HasKey(r => r.Id);
            modelBuilder.Entity<Artist>().HasKey(ar => ar.Id);
            modelBuilder.Entity<Movie>().HasKey(m => m.Id);
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<Session>().HasKey(s => s.Id);
            modelBuilder.Entity<ArtistMovie>().HasKey(am => new { am.MovieId, am.ArtistId });
            modelBuilder.Entity<GenreMovie>().HasKey(gm => new { gm.GenreId, gm.MovieId });
            modelBuilder.Entity<MovieTheater>().HasKey(mt => new { mt.AddressCompanyId, mt.MovieTheaterNumber });
            modelBuilder.Entity<Chair>().HasKey(ch => new { ch.AddressCompanyId, ch.MovieTheaterNumber, ch.Row, ch.Col });
            modelBuilder.Entity<Ticket>().HasKey(t => new { t.SessionId, t.ChairRow, t.ChairCol });
            #endregion

            //foreign key setup space
            #region fk
            modelBuilder.Entity<AddressPerson>().HasOne(a => a.Person).WithMany(p => p.Addresses).HasForeignKey(a => a.PersonId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Phone>().HasOne(ph => ph.Person).WithMany(p => p.Phones).HasForeignKey(p => p.PersonId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AddressCompany>().HasOne(a => a.Company).WithMany(c => c.Addresses).HasForeignKey(ac => ac.CompanyId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Phone>().HasOne(ph => ph.AddressCompany).WithMany(c => c.Phones).HasForeignKey(p => p.AddressCompanyId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArtistMovie>().HasOne(am => am.Artist).WithMany(a => a.Movies).HasForeignKey(am => am.ArtistId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ArtistMovie>().HasOne(am => am.Movie).WithMany(m => m.Artists).HasForeignKey(am => am.MovieId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GenreMovie>().HasOne(gm => gm.Genre).WithMany(g => g.GenreMovies).HasForeignKey(gm => gm.GenreId).IsRequired();
            modelBuilder.Entity<GenreMovie>().HasOne(gm => gm.Movie).WithMany(m => m.GenreMovies).HasForeignKey(gm => gm.MovieId).IsRequired();

            modelBuilder.Entity<Movie>().HasOne(m => m.Rating).WithMany(r => r.Movies).HasForeignKey(m => m.RatingId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<MovieTheater>().HasOne(mt => mt.AddressCompany).WithMany(ac => ac.MovieTheaters).HasForeignKey(mt => mt.AddressCompanyId);

            modelBuilder.Entity<Chair>().HasOne(ch => ch.MovieTheater).WithMany(mt => mt.Chairs).HasForeignKey(ch => new { ch.AddressCompanyId, ch.MovieTheaterNumber }).IsRequired().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>().HasOne(s => s.MovieTheater).WithMany(mt => mt.Sessions).HasForeignKey(s => new { s.AddressCompanyId, s.MovieTheaterNumber });
            modelBuilder.Entity<Session>().HasOne(s => s.Movie).WithMany(m => m.Sessions).HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<Ticket>().HasOne(t => t.Session).WithMany(s => s.Tickets).HasForeignKey(t=> t.SessionId).IsRequired();
            //modelBuilder.Entity<Session>().HasMany(s => s.Tickets).WithOne(t => t.Session).HasPrincipalKey(s => new { s.AddressCompanyId, s.MovieTheaterNumber, s.SessionTime }).HasConstraintName("fk_Ticket");
            //modelBuilder.Entity<Ticket>().HasOne(t => t.Chair).WithMany(ch=>ch.Tickets).IsRequired();
            #endregion

            //Espaço para propriedades
            #region properties
            //modelBuilder.Entity<Address>().Property<DateTime>("LastUpdated");
            modelBuilder.Entity<MovieTheater>().Property<int>("QtdRow").IsRequired();
            modelBuilder.Entity<MovieTheater>().Property<int>("QtdCol").IsRequired();
            #endregion

            //Herança
            #region heritage
            modelBuilder.Entity<Customer>().HasBaseType<Person>();
            modelBuilder.Entity<Employee>().HasBaseType<Person>();

            modelBuilder.Entity<AddressCompany>(ac => { ac.HasBaseType<Address>(); });
            modelBuilder.Entity<AddressPerson>(ac => { ac.HasBaseType<Address>(); });
            #endregion

            //Seeding the DataBase
            #region seed
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Cine Marx" }
            );

            modelBuilder.Entity<AddressCompany>().HasData(
                new AddressCompany { Id = 1, CompanyId = 1, City = "brasilia", District = "Asa Sul", Street = "sql", Number = 42, Complement = null, Country = "Brasil", State = "DF", ZipCode = 7000000, Name = "Brasilia Park"}
            );

            modelBuilder.Entity<MovieTheater>().HasData(
                new MovieTheater (qtdCol:10, qtdRow:10){ MovieTheaterNumber = 1, AddressCompanyId = 1}
            );

            // inicializa as cadeira da sala->todas.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var c = new Chair(i, j);
                    c.AddressCompanyId = 1;
                    c.MovieTheaterNumber = 1;
                    modelBuilder.Entity<Chair>().HasData(c);
                }
            }


            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Dovakin", LastName = "Alcantara", BirthDay = new DateTime(1911, 11, 11), CPF = "000.000.000-00", Email = "email@email", PassC = "muito louco" },
                new Customer { Id = 2, FirstName = "Machado", LastName = "de assis", BirthDay = new DateTime(1911, 11, 11), CPF = "333.333.333-33", Email = "email@email", PassC = "muito louco 2" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 3, FirstName = "Dovakin", LastName = "Alcantara", BirthDay = new DateTime(1911, 11, 11), CPF = "000.000.000-00", Cod = 123456, PassE = "12" }
            );

            modelBuilder.Entity<AddressPerson>().HasData(
                new AddressPerson { Id = 3, City = "brasilia", District = "Asa Sul", Street = "sql", Number = 42, Complement = null, Country = "Brasil", State = "DF", ZipCode = 7000000, PersonId = 1 },
                new AddressPerson { Id = 2, City = "brasilia", District = "Asa norte", Street = "Campus Darcy Ribeiro", Number = 0, Complement = "ICC Norte", Country = "Brasil", State = "DF", ZipCode = 70000000, PersonId = 2 }
            );

            modelBuilder.Entity<Phone>().HasData(
                new Phone { Id = 1, CountryCode = 55, AreaCode = 61, Number = 55551234, PersonId = 1 },
                new Phone { Id = 2, CountryCode = 55, AreaCode = 61, Number = 999954321, AddressCompanyId = 1 },
                new Phone { Id = 3, CountryCode = 55, AreaCode = 61, Number = 999912345, PersonId = 2 }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, Name = "Livre", Age = 0 },
                new Rating { Id = 2, Name = "NR 10", Age = 10 },
                new Rating { Id = 3, Name = "NR 12", Age = 12 },
                new Rating { Id = 4, Name = "NR 14", Age = 14 },
                new Rating { Id = 5, Name = "NR 16", Age = 16 },
                new Rating { Id = 6, Name = "NR 18", Age = 18 }
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "Silvester Stallone", Country = "USA", BirthDay = new DateTime(1946, 6, 6) },
                new Artist { Id = 2, Name = "Arnold Schwarzenegger", Country = "Autria", BirthDay = new DateTime(1947, 6, 30) }
            );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Rambo 3", Duration = 180, ReleaseDate = new DateTime(2000, 12, 25), RatingId = 6 },
                new Movie { Id = 2, Title = "Rambo 2", Duration = 200, ReleaseDate = new DateTime(1990, 12, 25), RatingId = 6 },
                new Movie { Id = 3, Title = "Rambo  ", Duration = 160, ReleaseDate = new DateTime(1985, 12, 25) }
            );

            modelBuilder.Entity<ArtistMovie>().HasData(
                new ArtistMovie { MovieId = 1, ArtistId = 1 },
                new ArtistMovie { MovieId = 2, ArtistId = 1 },
                new ArtistMovie { MovieId = 3, ArtistId = 1 },
                new ArtistMovie { MovieId = 1, ArtistId = 2 }
                );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "comedy" }
            );
            modelBuilder.Entity<GenreMovie>().HasData(
                new GenreMovie { MovieId = 1, GenreId = 1 },
                new GenreMovie { MovieId = 2, GenreId = 1 },
                new GenreMovie { MovieId = 3, GenreId = 1 }
                );
            modelBuilder.Entity<Session>().HasData(
                new Session { AddressCompanyId = 1, SessionTime = DateTime.Today.AddDays(3), MovieId = 3, MovieTheaterNumber = 1 , Id = 1}
                );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { SessionId = 1, ChairCol = 4, ChairRow = 5, Value = 10 }
                );
            #endregion
        }

        /// <summary>
        /// Funcao Configuracao
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;DataBase=unbcineflix;Uid=root;Pwd=@VTQpZGC8*qkj$uu");
            }
        }

        
    }
}
