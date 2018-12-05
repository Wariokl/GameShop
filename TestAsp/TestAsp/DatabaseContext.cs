using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAsp.Models;

namespace TestAsp
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Company> Companies { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> users { get; set; }  
        //public DbSet<Genre> Genries { get; set; }
        //public DbSet<Library> Libraries { get; set; }
        //public DbSet<Log> Log { get; set; }
        //public DbSet<GenreisGames> genreisGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=server;Password=server;database=mariadb;");
        }

    }
}

