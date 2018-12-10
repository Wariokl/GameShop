using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAsp.Models;

namespace TestAsp.Controllers
{
   // [Produces("application/json")]
    [Route("/Library")]
    public class LibraryController : Controller
    {
        private readonly DatabaseContext _context;



        public LibraryController(DatabaseContext context)
        {
            this._context = context;
        }


        [HttpGet]

        public JsonResult Get_Library()
        {
            var lib = _context.Libraries
                .Select(li => new
                {
                    li.LibraryID,
                    UserId = li.UserID.UserId,
                    GameID = li.GameId.Id          
                })
                .ToList();
            return Json(lib);
        }

        [HttpPost]
        public void Add_Company([FromHeader]string _gameid, [FromHeader]string _userid)
        {
           
            var g = _context.Games
        .Where(c => c.Id == Convert.ToInt32(_gameid))
        .FirstOrDefault();

            var u = _context.Users
        .Where(c => c.UserId == Convert.ToInt32(_userid))
        .FirstOrDefault();

            Library lib = new Library
            {
                GameId = g,
                UserID = u

            };           
            
            _context.Libraries.Add(lib);

            _context.SaveChanges();
        }

        [HttpDelete("{value}")]
        public void Delete_Library(string value)
        {
            string[] x = value.Split(';');
            var entity = _context.Libraries
                .Where(l => l.UserID.UserId == Convert.ToInt32(x[0]))
                .Where(l => l.GameId.Id == Convert.ToInt32(x[1]))
                .FirstOrDefault();
                
                
            _context.Libraries.Remove(entity);
            _context.SaveChanges();

        }


    }
}
