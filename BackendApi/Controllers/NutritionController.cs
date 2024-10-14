using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public NutritionController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Nutrition> nutritions = Context.Nutritions.ToList();
            return Ok(nutritions);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Nutrition? nutritions = Context.Nutritions.Where(x => x.NutritionId == id).FirstOrDefault();
            if (nutritions == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(nutritions);
        }

        [HttpPost]

        public IActionResult Add(Nutrition nutritions)
        {
            Context.Nutritions.Add(nutritions);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Nutrition nutritions)
        {
            Context.Nutritions.Update(nutritions);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Nutrition? nutritions = Context.Nutritions.Where(x => x.NutritionId == id).FirstOrDefault();
            if (nutritions == null)
            {
                return BadRequest("Not Found");
            }
            Context.Nutritions.Remove(nutritions);
            Context.SaveChanges();
            return Ok();
        }
    }
}
