using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageUsersController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public MessageUsersController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<MessageUser> messageUsers = Context.MessageUsers.ToList();
            return Ok(messageUsers);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            MessageUser? messageUsers = Context.MessageUsers.Where(x => x.MessageId == id).FirstOrDefault();
            if (messageUsers == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(messageUsers);
        }

        [HttpPost]

        public IActionResult Add(MessageUser messageUsers)
        {
            Context.MessageUsers.Add(messageUsers);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(MessageUser messageUsers)
        {
            Context.MessageUsers.Update(messageUsers);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            MessageUser? messageUsers = Context.MessageUsers.Where(x => x.MessageId == id).FirstOrDefault();
            if (messageUsers == null)
            {
                return BadRequest("Not Found");
            }
            Context.MessageUsers.Remove(messageUsers);
            Context.SaveChanges();
            return Ok();
        }
    }
}
