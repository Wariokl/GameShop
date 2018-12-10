using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAsp.Models;

namespace TestAsp.Controllers
{
    //Ready

    //[Produces("application/json")]
    [Route("/Category")]
    public class CategoryController : Controller
    {
        private readonly DatabaseContext _context;



        public CategoryController(DatabaseContext context)
        {
            this._context = context;
        }


        [HttpGet]

        public JsonResult Get_category()
        {

            var cat = _context.Categories.ToList();

            return Json(cat);

        }
       
        [HttpPost]
        public void Add_category([FromHeader]string _Name)
        {

            _context.Categories.Add(new Category { CategoryName = _Name });
            _context.SaveChanges();
        }
        [HttpPut("{value}")]

        public void Change_category(string value)
        {
            string[] x = value.Split(';');
            var entity = _context.Categories.Where(c => c.CategoryName == x[0]).ToList();
            foreach (var item in entity)
            {
                item.CategoryName = x[1];
            }
            _context.SaveChanges();
        }
        [HttpDelete("{value}")]

        public void Delete_category(string value)
        {

            var entity = _context.Categories
                .Where(c => c.CategoryName == value)
                .FirstOrDefault();
            _context.Categories.Remove(entity);
            _context.SaveChanges();

        }
    }
}
