using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public FriendController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Friend> friends = Context.Friends.ToList();
            return Ok(friends);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Friend? friends = Context.Friends.Where(x => x.FriendId == id).FirstOrDefault();
            if (friends == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(friends);
        }

        [HttpPost]

        public IActionResult Add(Friend friends)
        {
            Context.Friends.Add(friends);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Friend friends)
        {
            Context.Friends.Update(friends);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Friend? friends = Context.Friends.Where(x => x.FriendId == id).FirstOrDefault();
            if (friends == null)
            {
                return BadRequest("Not Found");
            }
            Context.Friends.Remove(friends);
            Context.SaveChanges();
            return Ok();
        }
    }
}
