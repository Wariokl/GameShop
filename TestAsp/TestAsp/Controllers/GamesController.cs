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

        public JsonResult Get_Game()
        {

            var ga = _context.Games
                .Select(game => new
                {
                    game.Id,
                    game.Name,

                    //GameGenre = game.genres.GenreName,
                    GameCategory = game.Categories.CategoryName,
                    GameCompany = game.Companies.CompanyName,
                   
                    GamePrice = game.Price

                })

                .ToList();
            List<List<GenreisGames>> ges = new List<List<GenreisGames>>();
            List<GenreisGames> ge = new List<GenreisGames>();
            for (int i = 0; i < ga.Count; i++)
            {
                ge = _context.genreisGames
               .Where(genre => genre.gameID == ga[i].Id)
               .ToList();
                ges.Add(ge);
            }
            return Json(ga);

        }

        [HttpPost("{value}")]
        public void Add_Game(string value, string value2)
        {
            string[] x = value.Split(';');

            var cat = _context.Categories
                .Find(Convert.ToInt32(x[1]));



            var comp = _context.Companies
                .Find(Convert.ToInt32(x[2]));
                


            





            Game game = new Game
            {
               Name=x[0],
               Categories = cat,
               Companies = comp,
               Price=Convert.ToInt32(x[3])                
            };

            _context.Games.Add(game);

            _context.SaveChanges();


            for (int i = x.Length - 1; i > 3; i--)
            {
                var gamegen = _context.Games
                    .LastOrDefault();
                var genre = _context.Genries
                    .Where(c => c.GenreName == x[i])
                    .FirstOrDefault();
                GenreisGames genreisGames = new GenreisGames
                {
                    gameID = gamegen.Id,
                    genreID = genre.GenreID


                };
                _context.genreisGames.Add(genreisGames);
                _context.SaveChanges();
            }
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
