using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAsp.Models;

namespace TestAsp.Controllers
{
    [Produces("application/json")]
    [Route("Games")]
    public class GamesController : Controller
    {

        private readonly DatabaseContext _context;



        public GamesController(DatabaseContext context)
        {
            this._context = context;
        }

        [HttpGet]

        public JsonResult Get_Game([FromHeader]string _Name, [FromHeader]string _Category, [FromHeader]string _Company, [FromHeader]string _Genre , [FromHeader]string _Price)
        {

            var ga = _context.Games
                .Select(game => new
                {
                    game.Id,
                    game.Name,                    
                    GameCategory = game.Categories.CategoryName,
                    GameCompany = game.Companies.CompanyName,                   
                    GamePrice = game.Price,
                    GameGenre = game.genres.GenreName

                })
                .ToList();

            if (_Name != "")
            {
                
                for (int i = 0; i < ga.Count; i++)
                {
                    if (ga[i].Name!=_Name)
                    {
                        ga.RemoveAt(i);
                        i--;
                    }
                }
            }
            if (_Category != "")
                for (int i = 0; i < ga.Count; i++)
                {
                    if (ga[i].GameCategory != _Category)
                    {
                        ga.RemoveAt(i);
                        i--;
                    }
                }
            if (_Company != "")
                for (int i = 0; i < ga.Count; i++)
                {
                    if (ga[i].GameCompany != _Company)
                    {
                        ga.RemoveAt(i);
                        i--;
                    }
                }
            if (_Price != "")
                for (int i = 0; i < ga.Count; i++)
                {
                    if (ga[i].GamePrice > Convert.ToInt32(_Price))
                    {
                        ga.RemoveAt(i);
                        i--;
                    }
                }
            if (_Genre != "")
                for (int i = 0; i < ga.Count; i++)
                {
                    if (ga[i].GameGenre !=_Genre)
                    {
                        ga.RemoveAt(i);
                        i--;
                    }
                }




            return Json(ga);

        }

        [HttpPost]
        public void Add_Game([FromHeader]string _Name, [FromHeader]string _Category, [FromHeader]string _Company, [FromHeader]string _Genre, [FromHeader]string _Price)
        {


            var cat = _context.Categories
                .Where(c => c.CategoryName == _Category)
                .FirstOrDefault();
                



            var comp = _context.Companies
                .Where(c => c.CompanyName == _Company)
                .FirstOrDefault();

            var genr = _context.Genries
                .Where(c => c.GenreName == _Genre)
                .FirstOrDefault();





            Game game = new Game
            {
                Name = _Name,
                genres = genr,
               Categories = cat,
               Companies = comp,
               Price=Convert.ToInt32(_Price)                
            };

            _context.Games.Add(game);

            _context.SaveChanges();


            
        }

        [HttpDelete("{value}")]
        public void Delete_Game(string value)
        {
            
            var entity = _context.Games
                .Where(l => l.Name == value)
               
                .FirstOrDefault();


            _context.Games.Remove(entity);
            _context.SaveChanges();

        }
    }
}
