using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using UnBCineFlix.Models;

namespace UnBCineFlix.DAL
{
    public class UnBCineFlixContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public UnBCineFlixContext()
        {

        }
        public UnBCineFlixContext(DbContextOptions<UnBCineFlixContext> option)
    : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Primary Key setup space
            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Phone>().HasKey(ph => ph.Id);
            modelBuilder.Entity<Rating>().HasKey(r => r.Id);
            modelBuilder.Entity<Artist>().HasKey(ar => ar.Id);
            modelBuilder.Entity<Movie>().HasKey(m => m.Id);
            modelBuilder.Entity<Company>().HasKey(c => c.Id);
            modelBuilder.Entity<ArtistMovie>().HasKey(am => new { am.MovieId, am.ArtistId });

            //foreign key setup space
            //modelBuilder.Entity<Address>().HasOne(a => a.Person).WithMany(p => p.Addresses).HasForeignKey(a => a.PersonId);
            //modelBuilder.Entity<Person>().HasMany(p => p.Addresses).WithOne(a => a.Person).HasPrincipalKey(p => p.Id).IsRequired(false);
            modelBuilder.Entity<Address>().HasOne(a => a.Person).WithMany(p => p.Addresses).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Phone>().HasOne(ph => ph.Person).WithMany(p => p.Phones).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>().HasOne(a => a.Company).WithMany(p => p.Addresses).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Phone>().HasOne(ph => ph.Company).WithMany(p => p.Phones).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ArtistMovie>().HasOne(am => am.Artist).WithMany(a => a.Movies).HasForeignKey(am => am.ArtistId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ArtistMovie>().HasOne(am => am.Movie).WithMany(m => m.Artists).HasForeignKey(am => am.MovieId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Movie>().HasOne(m => m.Rating).WithMany(r => r.Movies).HasForeignKey(m => m.RatingId).OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Address>().Property<DateTime>("LastUpdated");

            modelBuilder.Entity<Customer>().HasBaseType<Person>();
            modelBuilder.Entity<Employee>().HasBaseType<Person>();

            //Seeding the DataBase
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Dovakin", LastName = "Alcantara", BirthDay = new DateTime(1911, 11, 11), CPF = "000.000.000-00", Email="email@email", PassC = "muito louco" },
                new Customer { Id = 2, FirstName = "Machado", LastName = "de assis", BirthDay = new DateTime(1911, 11, 11), CPF = "333.333.333-33" , Email="email@email", PassC = "muito louco 2"}
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 3, FirstName = "Dovakin", LastName = "Alcantara", BirthDay = new DateTime(1911, 11, 11), CPF = "000.000.000-00", Cod = 123456, PassE="12" }
                );

            modelBuilder.Entity<Company>().HasData(
                new Company {Id = 1 }
                );
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, City = "brasilia", District = "Asa Sul", Street = "sql", Number = 42, Complement = null, Country = "Brasil", State = "DF", ZipCode = 7000000, PersonId = 1},
                new Address { Id = 2, City = "brasilia", District = "Asa norte", Street = "Campus Darcy Ribeiro", Number = 0, Complement = "ICC Norte", Country = "Brasil", State = "DF", ZipCode = 70000000, CompanyId = 1 }
            );

            modelBuilder.Entity<Phone>().HasData(
                new Phone { Id = 1, CountryCode = 55, AreaCode = 61, Number = 55551234, PersonId = 1, CompanyId = 1 },
                new Phone { Id = 2, CountryCode = 55, AreaCode = 61, Number = 999954321, PersonId = 1, CompanyId = 1 },
                new Phone { Id = 3, CountryCode = 55, AreaCode = 61, Number = 999912345, PersonId = 2, CompanyId = 1 }
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
                new Artist {Id = 1,Name = "Silvester Stallone",Country = "USA",BirthDay = new DateTime(1946, 6, 6)},
                new Artist {Id = 2,Name = "Arnold Schwarzenegger", Country="Autria",BirthDay = new DateTime(1947,6,30) }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Rambo 3", Duration = 180, ReleaseDate = new DateTime(2000, 12, 25), RatingId = 6 },
                new Movie { Id = 2, Title = "Rambo 2", Duration = 200, ReleaseDate = new DateTime(1990, 12, 25), RatingId = 6 },
                new Movie { Id = 3, Title = "Rambo  ", Duration = 160, ReleaseDate = new DateTime(1985, 12, 25), RatingId = 6 }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;DataBase=unbcineflix;Uid=root;Pwd=@VTQpZGC8*qkj$uu");
            }
        }
    }
}
