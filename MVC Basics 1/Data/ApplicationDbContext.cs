using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }
        public DbSet<PeopleModel> People { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<LanguageModel> Languages { get; set; }
        public DbSet<People_LanguageModel> PeopleLanguages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CityModel>()
              .HasOne<CountryModel>(co => co.Country)
              .WithMany(c => c.Cities)
              .HasForeignKey(co => co.CountryCode).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PeopleModel>()
                .HasOne<CityModel>(ci => ci.City)
                .WithMany(p => p.People)
                .HasForeignKey(ci => ci.CityID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<People_LanguageModel>().HasKey(co => new { co.PersonId, co.LanguageID });

            modelBuilder.Entity<People_LanguageModel>()
                .HasOne(p => p.People)
                .WithMany(l => l.PeopleLanguages)
                .HasForeignKey(p => p.PersonId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<People_LanguageModel>()
                .HasOne(l => l.Language)
                .WithMany(p => p.PeopleLanguages)
                .HasForeignKey(l => l.LanguageID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Code = "GHA", Name = "Ghana", Continent = "Africa", Population = 20212000 });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Code = "GBR", Name = "United Kingdom", Continent = "Europe", Population = 59623400 });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Code = "SWE", Name = "Sweden", Continent = "Europe", Population = 10188382 });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { Code = "USA", Name = "United States", Continent = "North America", Population = 278357000 });

            modelBuilder.Entity<CityModel>().HasData(new CityModel { ID = 1, Name = "Vänersborg", CountryCode = "SWE", Population = 39606 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { ID = 2, Name = "Göteborg", CountryCode = "SWE", Population = 1060000 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { ID = 3, Name = "Stockholm", CountryCode = "SWE", Population = 1657000 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { ID = 4, Name = "Trollhättan", CountryCode = "SWE", Population = 54487 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { ID = 5, Name = "London", CountryCode = "GBR", Population = 961989 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { ID = 6, Name = "Washington D.C.", CountryCode = "USA", Population = 689545 });

            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 1,
                FullName = "Ekram Ahmedin",
                CityID = 1,
                PhoneNumber = "0791234567",
                Email = "ekram234@gmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 2,
                FullName = "Eve Andersson",
                CityID = 2,
                PhoneNumber = "+46701297530",
                Email = "timsnds241@gmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 3,
                FullName = "Ulf David",
                CityID = 1,
                PhoneNumber = "0752875207",
                Email = "ulf78s3@hotmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 4,
                FullName = "Ali Muhammed",
                CityID = 4,
                PhoneNumber = "0796078542",
                Email = "alimuhammed@gmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 5,
                FullName = "Maria Svensson",
                CityID = 3,
                PhoneNumber = "+46791028376",
                Email = "mariaSvensson234@gmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 6,
                FullName = "Rahwa Suliman",
                CityID = 3,
                PhoneNumber = "0764933276",
                Email = "RahwaSuliman1234@gmail.com"
            });

            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel {LanguageID = 1, Name = "English" , Description = "The international language spoken by many people around the world"});
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageID = 2, Name = "Arabic", Description = "The  second international language spoken by in the different region of the world" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageID = 3, Name = "Swedish", Description = "The main language spoken in the Sweden Country" });

            modelBuilder.Entity<People_LanguageModel>().HasData(new People_LanguageModel {PersonId = 1 , LanguageID =3} );
            modelBuilder.Entity<People_LanguageModel>().HasData(new People_LanguageModel { PersonId = 1, LanguageID = 2 });
            modelBuilder.Entity<People_LanguageModel>().HasData(new People_LanguageModel { PersonId = 1, LanguageID = 1 });
            modelBuilder.Entity<People_LanguageModel>().HasData(new People_LanguageModel { PersonId = 2, LanguageID = 3 });
            modelBuilder.Entity<People_LanguageModel>().HasData(new People_LanguageModel { PersonId = 2, LanguageID = 1 });
            modelBuilder.Entity<People_LanguageModel>().HasData(new People_LanguageModel { PersonId = 3, LanguageID = 3 });
            modelBuilder.Entity<People_LanguageModel>().HasData(new People_LanguageModel { PersonId = 4, LanguageID = 2 });


        }
    }
}
