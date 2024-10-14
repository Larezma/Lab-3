using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public PublicationController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Publication> publications = Context.Publications.ToList();
            return Ok(publications);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Publication? publication = Context.Publications.Where(x => x.PublicationsId == id).FirstOrDefault();
            if (publication == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(publication);
        }

        [HttpPost]

        public IActionResult Add(Publication publication)
        {
            Context.Publications.Add(publication);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Publication publication)
        {
            Context.Publications.Update(publication);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Role? role = Context.Roles.Where(x => x.Id == id).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Not Found");
            }
            Context.Roles.Remove(role);
            Context.SaveChanges();
            return Ok();
        }
    }
}
