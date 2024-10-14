using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserToAchievementsController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public UserToAchievementsController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<UserToAchievement> UserToAchievements = Context.UserToAchievements.ToList();
            return Ok(UserToAchievements);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            UserToAchievement? UserToAchievements = Context.UserToAchievements.Where(x => x.Id == id).FirstOrDefault();
            if (UserToAchievements == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(UserToAchievements);
        }

        [HttpPost]

        public IActionResult Add(UserToAchievement UserToAchievements)
        {
            Context.UserToAchievements.Add(UserToAchievements);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(UserToAchievement UserToAchievements)
        {
            Context.UserToAchievements.Update(UserToAchievements);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            UserToAchievement? UserToAchievements = Context.UserToAchievements.Where(x => x.Id == id).FirstOrDefault();
            if (UserToAchievements == null)
            {
                return BadRequest("Not Found");
            }
            Context.UserToAchievements.Remove(UserToAchievements);
            Context.SaveChanges();
            return Ok();
        }
    }
}
