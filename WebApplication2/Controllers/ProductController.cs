using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public  IActionResult Create(Product product)
        {   
             _context.Products.Add(product);
             _context.SaveChanges();
            return StatusCode(201,product);
        }

        [HttpPut]

        public IActionResult Put(int id ,Product product) { 
                         var updatedData =_context.Products.FirstOrDefault(x=>x.Id == id);
            if (updatedData == null) {
                return BadRequest("Id tapilmadi !!!");
            }
  
            updatedData.Name = product.Name;
            _context.Products.Update(updatedData);
            _context.SaveChanges();


                    return StatusCode(201,updatedData); 
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var deletedData= _context.Products.FirstOrDefault(y=>y.Id == id);
            if (deletedData == null) { 
                return BadRequest();            
            }
            _context.Products.Remove(deletedData);
            _context.SaveChanges();
            return StatusCode(201,deletedData);
         
        }

        [HttpGet("all")]
        public IActionResult GetAll() {

            IEnumerable<Product> list = _context.Products.ToList();
            
            return StatusCode(201,list);       
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var gettingData = _context.Products.FirstOrDefault(x => x.Id == id);
            if(gettingData == null)
            {
                return BadRequest("Id tapilmadi !!!");
            }

            return StatusCode(201,gettingData);
        }

    }
}
