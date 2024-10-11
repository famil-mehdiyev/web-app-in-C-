using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApplication2.Context;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Category.Add(category);


            _context.SaveChanges();
            return StatusCode(201, category);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedData = _context.Category.FirstOrDefault(x => x.id == id);

            if (deletedData is null)
            {
                return BadRequest("Id tapilmadi..");
            }

            _context.Category.Remove(deletedData);


            _context.SaveChanges();
            return StatusCode(201, deletedData);
        }
        [HttpPut]
        public IActionResult Put(int id, Category categories)
        {
            var updatedData = _context.Category.FirstOrDefault(x => x.id == id);
            if (updatedData is null)
            {
                return BadRequest("Id tapilmadi !!1");
            }
            updatedData.name = categories.name;
            _context.Category.Update(updatedData);
            _context.SaveChanges();

            return StatusCode(201, updatedData);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var gettingId = _context.Category.FirstOrDefault(x => x.id == id);
            return StatusCode(201, gettingId);

        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            IEnumerable<Category> list = _context.Category.ToList(); 
            return StatusCode(201, list);

        }


    }

}