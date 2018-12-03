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
        public DatabaseContext(DbContextOptions options ) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Library> Library { get; set; }
        public DbSet<Log> Log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=server;Password=server;database=mariadb;");
        }
        //(options => options.UseMySql("server=localhost;UserId=server;Password=server;database=mariadb;"))
    }
}

