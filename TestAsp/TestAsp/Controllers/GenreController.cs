using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAsp.Models;

namespace TestAsp.Controllers
{
   // [Produces("application/json")]
    [Route("genre")]
    public class GenreController : Controller
    {
        private readonly DatabaseContext _context;



        public GenreController(DatabaseContext context)
        {
            this._context = context;
        }

        [HttpGet]

        public JsonResult Get_Genre()
        {

            var cat = _context.Genries.ToList();

            return Json(cat);

        }

        [HttpPost]
        public void Add_Genre([FromHeader]string _Name)
        {
            
            _context.Genries.Add(new Genre
            {
                GenreName=_Name

            });
            _context.SaveChanges();
        }

        [HttpPut("{value}")]

        public void Change_genre(string value)
        {
            string[] x = value.Split(';');
            var entity = _context.Genries.Where(g => g.GenreName == x[0]).ToList();
            foreach (var item in entity)
            {
                item.GenreName = x[1];
            }
            _context.SaveChanges();
        }

        [HttpDelete("{value}")]

        public void Delete_genre(string value)
        {

            var entity = _context.Genries
                .Where(g => g.GenreName == value)
                .FirstOrDefault();
            _context.Genries.Remove(entity);
            _context.SaveChanges();



        }
    }
}
