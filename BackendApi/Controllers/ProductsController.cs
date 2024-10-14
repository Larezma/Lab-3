using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public ProductsController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Product> products = Context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Product? product = Context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(product);
        }

        [HttpPost]

        public IActionResult Add(Product product)
        {
            Context.Products.Add(product);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Product product)
        {
            Context.Products.Update(product);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Product? product = Context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return BadRequest("Not Found");
            }
            Context.Products.Remove(product);
            Context.SaveChanges();
            return Ok();
        }
    }
}
