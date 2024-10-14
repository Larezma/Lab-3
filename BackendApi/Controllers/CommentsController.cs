using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public CommentsController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Comment> Comments = Context.Comments.ToList();
            return Ok(Comments);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Comment? Comments = Context.Comments.Where(x => x.CommentsId == id).FirstOrDefault();
            if (Comments == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Comments);
        }

        [HttpPost]

        public IActionResult Add(Comment Comments)
        {
            Context.Comments.Add(Comments);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Comment Comments)
        {
            Context.Comments.Update(Comments);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Comment? Comments = Context.Comments.Where(x => x.CommentsId == id).FirstOrDefault();
            if (Comments == null)
            {
                return BadRequest("Not Found");
            }
            Context.Comments.Remove(Comments);
            Context.SaveChanges();
            return Ok();
        }
    }
}
