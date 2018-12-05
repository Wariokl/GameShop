using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAsp.Models;

namespace TestAsp.Controllers
{
    [Route("/")]
    public class ValuesController : Controller
    {
        private readonly DatabaseContext _context;

    

        public ValuesController(DatabaseContext context)
        {
            this._context = context;
        }
       
        
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            _context.Database.EnsureCreated();
            var users = _context.Games.ToList();
            _context.SaveChanges();
            return Json(users);
            
        }

       

        //POST api/values
        [HttpPost]
        public void AddGame([FromHeader]string _Name, [FromHeader]int _Companyid, [FromHeader]int _categoryid, [FromHeader]string _genreid)
        {

        }
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
           
        }
    }
}
