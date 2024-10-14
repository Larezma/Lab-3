using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNutritionController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public UserNutritionController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<UserNutrition> UserNutritions = Context.UserNutritions.ToList();
            return Ok(UserNutritions);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            UserNutrition? UserNutritions = Context.UserNutritions.Where(x => x.UserNutritionId == id).FirstOrDefault();
            if (UserNutritions == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(UserNutritions);
        }

        [HttpPost]

        public IActionResult Add(UserNutrition UserNutritions)
        {
            Context.UserNutritions.Add(UserNutritions);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(UserNutrition UserNutritions)
        {
            Context.UserNutritions.Update(UserNutritions);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            UserNutrition? UserNutritions = Context.UserNutritions.Where(x => x.UserNutritionId == id).FirstOrDefault();
            if (UserNutritions == null)
            {
                return BadRequest("Not Found");
            }
            Context.UserNutritions.Remove(UserNutritions);
            Context.SaveChanges();
            return Ok();
        }
    }
}
