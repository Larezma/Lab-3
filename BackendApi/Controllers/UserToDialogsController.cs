using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserToDialogsController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public UserToDialogsController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<UserToDialog> UserToDialogs = Context.UserToDialogs.ToList();
            return Ok(UserToDialogs);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            UserToDialog? UserToDialogs = Context.UserToDialogs.Where(x => x.Id == id).FirstOrDefault();
            if (UserToDialogs == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(UserToDialogs);
        }

        [HttpPost]

        public IActionResult Add(UserToDialog UserToDialogs)
        {
            Context.UserToDialogs.Add(UserToDialogs);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(UserToDialog UserToDialogs)
        {
            Context.UserToDialogs.Update(UserToDialogs);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            UserToDialog? UserToDialogs = Context.UserToDialogs.Where(x => x.Id == id).FirstOrDefault();
            if (UserToDialogs == null)
            {
                return BadRequest("Not Found");
            }
            Context.UserToDialogs.Remove(UserToDialogs);
            Context.SaveChanges();
            return Ok();
        }
    }
}
