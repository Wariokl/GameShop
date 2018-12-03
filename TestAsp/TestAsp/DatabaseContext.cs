using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TestAsp
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options ) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=server;Password=server;database=mariadb;");
        }
        //(options => options.UseMySql("server=localhost;UserId=server;Password=server;database=mariadb;"))
    }
}

