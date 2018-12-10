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

        [HttpPost]
        public bool Add_user([FromHeader]string L, [FromHeader]string P, [FromHeader]string N)
        {
            try
            {
                var entity = _context.Users
                        .Where(l => l.Login == L || l.NickName == N)                       
                        .First();
                return false;   
            }

            catch
            {
                _context.Users.Add(new User
                {
                    NickName = N,
                    Login = L,
                    Password = P



                });
                _context.SaveChanges();
                return true;
            }
          
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
        [Route("login")]
        [HttpGet]
        public string IsUserExist([FromHeader]string Login, [FromHeader]string Password)
        {
            string AccsesToken="true";
            try
            {
                var entity = _context.Users
                    .Where(l => l.Login == Login)
                    .Where(l => l.Password == Password)
                    .First();
                AccsesToken += ';';
                AccsesToken += Convert.ToString(entity.UserId);
                return AccsesToken;
            }

            catch
            {

                AccsesToken = "false";
                return AccsesToken;
            }


            
        }
        
    }
}
