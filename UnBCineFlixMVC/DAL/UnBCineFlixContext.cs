using Microsoft.EntityFrameworkCore;
using System;
using UnBCineFlix.Models;

namespace UnBCineFlix.DAL
{
    public class UnBCineFlixContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public UnBCineFlixContext()
        {

        }
        public UnBCineFlixContext(DbContextOptions<UnBCineFlixContext> option)
    : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Phone>().HasKey(p => p.Id);
            modelBuilder.Entity<Rating>().HasKey(p => p.Id);
            modelBuilder.Entity<Artist>().HasKey(p => p.Id);

            modelBuilder.Entity<Address>().HasOne(a => a.Person).WithMany(b => b.Addresses).HasForeignKey(p => p.PersonId);
            modelBuilder.Entity<Phone>().HasOne(a => a.Person).WithMany(p => p.Phones).HasForeignKey(a => a.PersonId);
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Felipe Luis", LastName = "Pinheiro", BirthDay = new DateTime(1985, 05, 01), CPF = "012.109.651-35" },
                new Person { Id = 2, FirstName = "Cleonilde", LastName = "Pinheiro", BirthDay = new DateTime(1962, 10, 19), CPF = "376.646.971-15" }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, City = "brasilia", District = "Taguatinga norte", Street = "qnb 03", Number = 25, Complement = null, Country = "Brasil", State = "DF", ZipCode = 72115030, PersonId = 1 },
                new Address { Id = 2, City = "brasilia", District = "Asa norte", Street = "Campus Darcy Ribeiro", Number = 0, Complement = "ICC Norte", Country = "Brasil", State = "DF", ZipCode = 70000000, PersonId = 1 }
            );

            modelBuilder.Entity<Phone>().HasData(
                new Phone { Id = 1, CountryCode = 55, AreaCode = 61, Number = 32631773, PersonId = 1 },
                new Phone { Id = 2, CountryCode = 55, AreaCode = 61, Number = 995599515, PersonId = 1 },
                new Phone { Id = 3, CountryCode = 55, AreaCode = 61, Number = 999869099, PersonId = 2 }
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
                new Artist
                {
                    Id = 1,
                    Name = "Silvester Stallone",
                    Country = "USA",
                    BirthDay = new DateTime(1946, 6, 6)
                }
                );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;DataBase=unbcineflix;Uid=root;Pwd=@VTQpZGC8*qkj$uu");
        }
    }
}
