using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestAsp.Controllers
{
    [Route("/")]
    public class ValuesController : Controller
    {
        //Messages messages = new Messages();

        public ValuesController()
        {
            
        }
        // GET api/values
        [HttpGet]
        public List<User> Get()
        {
            DbContextOptions<DatabaseContext> options = new DbContextOptions<DatabaseContext>();

            using (DatabaseContext db = new DatabaseContext(options))
            {
                List<User> users = db.Users.ToList();
                return users;
            }

            //return new string[] { "ASP", "is", "cool" };
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<string> Get(int id)
        {
            return Messages.messages;
        }
        [HttpPost]
        public void AddUser([FromHeader]string name, [FromHeader]string lastname)
        {
            DbContextOptions<DatabaseContext> options = new DbContextOptions<DatabaseContext>();
            using (DatabaseContext db = new DatabaseContext(options))
            {
                db.Database.EnsureCreated();
                User user = new User{ Name = name, Lastname = lastname };
                db.Users.Add(user);
                db.SaveChanges();                
            }
        }

        // POST api/values
        //[HttpPost]
        //public List<string> Post([FromBody]string value, [FromHeader]string name)
        //{
        //    if (name.Length != 0)
        //    {
        //        value = name + ": " + value;
        //        Console.WriteLine("Отправлена запись: {0}", value);
        //        Messages.messages.Add(value);
                
        //    }
        //    else
        //    {
        //        value = "[" + value + "]";
        //        Console.WriteLine("Пользователь присоединился");
        //        Messages.messages.Add(value);
        //    }
        //    return Messages.messages;
        //}
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
        [HttpDelete]
        public void Delete()
        {
            Messages.messages.Clear();
        }
    }
}
