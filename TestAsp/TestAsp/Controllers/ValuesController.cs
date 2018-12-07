using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAsp.Models;

namespace TestAsp.Controllers
{
   
    public class ValuesController : Controller
    {
        private readonly DatabaseContext _context;

    

        public ValuesController(DatabaseContext context)
        {
            this._context = context;
        }


        //// GET api/values
        //[Route("/games")]
        //[HttpGet]
        //public JsonResult Get_games()
        //{

        //    var users = _context.Games.ToList();

        //    return Json(users);

        //}


        //[Route("/genre")]
        //[HttpGet]
        //public JsonResult Get_genre()
        //{

        //    var cat = _context.Genries.ToList();

        //    return Json(cat);

        //}

        //[Route("/ccompany")]

        //[HttpGet]
        //public JsonResult Get_company()
        //{

        //    var cat = _context.Companies.ToList();

        //    return Json(cat);

        //}

        //[Route("/library")]
        //[HttpGet]
        //public JsonResult Get_libarary()
        //{

        //    var cat = _context.Libraries.ToList();

        //    return Json(cat);

        //}
        //[Route("/users")]
        //[HttpGet]
        //public JsonResult Get()
        //{

        //    var users = _context.Users.ToList();

        //    return Json(users);

        //}
        [Route("/")]
        [HttpGet]
        public void set_tabels()
        {
            _context.Database.EnsureCreated();

            _context.SaveChanges();


        }

        ////POST api/values
        //[HttpPost]
        //public void AddGame([FromHeader]string _Name, [FromHeader]int _Companyid, [FromHeader]int _categoryid, [FromHeader]string _genreid)
        //{

        //}
        //// PUT api/values/5

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{

        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
        //[HttpDelete]
        //public void Delete()
        //{

        //}
    }
}
