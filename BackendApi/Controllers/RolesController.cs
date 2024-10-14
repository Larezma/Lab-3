using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public RolesController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Role> roles = Context.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Role? role = Context.Roles.Where(x => x.Id == id).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(role);
        }

        [HttpPost]

        public IActionResult Add(Role role)
        {
            Context.Roles.Add(role);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Role role)
        {
            Context.Roles.Update(role);
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
