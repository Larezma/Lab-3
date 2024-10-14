using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public UserController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        [HttpPost]

        public IActionResult Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if(user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }
    }
}
