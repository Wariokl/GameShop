using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TestAsp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DbContextOptions<DatabaseContext> options = new DbContextOptions<DatabaseContext>();
            using (DatabaseContext db = new DatabaseContext(options))
            {
                //db.Database.EnsureCreated();
                // User user = new User { Name = name, Lastname = lastname };
                // db.Users.Add(user);
                db.SaveChanges();
            }

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseMySql("server=localhost;UserId=server;Password=server;database=mariadb;"));
            services.AddMvc();
           // services.AddSingleton();
            
            //services.AddSingleton<Messages>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
           
        }

    }
}
