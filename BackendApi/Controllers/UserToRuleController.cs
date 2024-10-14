using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserToRuleController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public UserToRuleController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<UserToRule> UserToRules = Context.UserToRules.ToList();
            return Ok(UserToRules);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            UserToRule? UserToRules = Context.UserToRules.Where(x => x.Id == id).FirstOrDefault();
            if (UserToRules == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(UserToRules);
        }

        [HttpPost]

        public IActionResult Add(UserToRule UserToRules)
        {
            Context.UserToRules.Add(UserToRules);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(UserToRule UserToRules)
        {
            Context.UserToRules.Update(UserToRules);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            UserToRule? UserToRules = Context.UserToRules.Where(x => x.Id == id).FirstOrDefault();
            if (UserToRules == null)
            {
                return BadRequest("Not Found");
            }
            Context.UserToRules.Remove(UserToRules);
            Context.SaveChanges();
            return Ok();
        }
    }
}
