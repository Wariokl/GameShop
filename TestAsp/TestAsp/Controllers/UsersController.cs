using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAsp.Models;

namespace TestAsp.Controllers
{
   
    [Route("user")]
    public class UsersController : Controller
    {

        private readonly DatabaseContext _context;



        public UsersController(DatabaseContext context)
        {
            this._context = context;
        }

        [HttpGet]

        public JsonResult Get_User()
        {

            var cat = _context.Users.ToList();

            return Json(cat);

        }

        [HttpPost("{value}")]
        public void Add_user(string value)
        {
            string[] x = value.Split(';');
            _context.Users.Add(new User
            {  
              NickName=x[0],
              Login=x[1],
              Password=x[2]
                           
            });
            _context.SaveChanges();
        }

        [HttpPut("{value}")]

        public void Change_User(string value)
        {
            string[] x = value.Split(';');
            var entity = _context.Users.Where(u => u.NickName == x[0]).ToList();
            foreach (var item in entity)
            {
                item.NickName = x[1];
            }
            _context.SaveChanges();
        }

        [HttpDelete("{value}")]

        public void Delete_User(string value)
        {

            var entity = _context.Users
                .Where(u => u.Login == value)
                .FirstOrDefault();
            _context.Users.Remove(entity);
            _context.SaveChanges();

        }

    }
}
