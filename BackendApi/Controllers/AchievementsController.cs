using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public AchievementsController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Achievement> Achievements = Context.Achievements.ToList();
            return Ok(Achievements);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Achievement? Achievements = Context.Achievements.Where(x => x.AchievementsId == id).FirstOrDefault();
            if (Achievements == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Achievements);
        }

        [HttpPost]

        public IActionResult Add(Achievement Achievements)
        {
            Context.Achievements.Add(Achievements);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Achievement Achievements)
        {
            Context.Achievements.Update(Achievements);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Achievement? Achievements = Context.Achievements.Where(x => x.AchievementsId == id).FirstOrDefault();
            if (Achievements == null)
            {
                return BadRequest("Not Found");
            }
            Context.Achievements.Remove(Achievements);
            Context.SaveChanges();
            return Ok();
        }
    }
}
