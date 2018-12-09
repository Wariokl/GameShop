using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAsp.Models;

namespace TestAsp.Controllers
{
    //ready
   // [Produces("application/json")]
    [Route("/Company")]
    public class CompanyController : Controller
    {
        private readonly DatabaseContext _context;



        public CompanyController(DatabaseContext context)
        {
            this._context = context;
        }


        [HttpGet]

        public JsonResult Get_Company()
        {

            var cat = _context.Companies.ToList();

            return Json(cat);

        }

        [HttpPost("{value}")]
        public void set_Company(string value,string value2)
        {
            string[] x= value.Split(';');
            _context.Companies.Add(new Company { CompanyName= x[0] ,Country=x[1]});

            _context.SaveChanges();
        }

        [HttpPut("{value}")]

        public void Change_category(string value)
        {
            string[] x = value.Split(';');
            var entity = _context.Companies.Where(c => c.CompanyName == x[0]).ToList();
            foreach (var item in entity)
            {
                item.CompanyName = x[1];
            }
            _context.SaveChanges();
        }

        [HttpDelete("{value}")]

        public void Delete_category(string value)
        {

            var entity = _context.Companies
                .Where(c => c.CompanyName == value)
                .FirstOrDefault();
            _context.Companies.Remove(entity);
            _context.SaveChanges();

        }
    }
}
