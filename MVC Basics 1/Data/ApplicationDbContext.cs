using Microsoft.EntityFrameworkCore;
using MVC_Basics_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics_1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }
        public DbSet<PeopleModel> People { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 1,
                FullName = "Ekram Ahmedin",
                City = "Vänersborg",
                PhoneNumber = "0791234567",
                Email = "ekram234@gmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 2,
                FullName = "Eve Andersson",
                City = "Göteborg",
                PhoneNumber = "+46701297530",
                Email = "timsnds241@gmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 3,
                FullName = "Ulf David",
                City = "Vänersborg",
                PhoneNumber = "0752875207",
                Email = "ulf78s3@hotmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 4,
                FullName = "Ali Muhammed",
                City = "Trollhättan",
                PhoneNumber = "0796078542",
                Email = "alimuhammed@gmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 5,
                FullName = "Maria Svensson",
                City = "Stockholm",
                PhoneNumber = "+46791028376",
                Email = "mariaSvensson234@gmail.com"
            });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel
            {
                PersonId = 6,
                FullName = "Rahwa Suliman",
                City = "Stockholm",
                PhoneNumber = "0764933276",
                Email = "RahwaSuliman1234@gmail.com"
            });
        }
    }
}
