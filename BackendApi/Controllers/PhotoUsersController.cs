using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoUsersController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public PhotoUsersController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<PhotoUser> photoUsers = Context.PhotoUsers.ToList();
            return Ok(photoUsers);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            PhotoUser? photoUsers = Context.PhotoUsers.Where(x => x.PhotoId == id).FirstOrDefault();
            if (photoUsers == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(photoUsers);
        }

        [HttpPost]

        public IActionResult Add(PhotoUser photoUsers)
        {
            Context.PhotoUsers.Add(photoUsers);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(PhotoUser photoUsers)
        {
            Context.PhotoUsers.Update(photoUsers);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            PhotoUser? photoUsers = Context.PhotoUsers.Where(x => x.PhotoId == id).FirstOrDefault();
            if (photoUsers == null)
            {
                return BadRequest("Not Found");
            }
            Context.PhotoUsers.Remove(photoUsers);
            Context.SaveChanges();
            return Ok();
        }
    }
}
