using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Group = BackendApi.Models.Group;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public GroupsController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Group> groups = Context.Groups.ToList();
            return Ok(groups);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Group? groups = Context.Groups.Where(x => x.GroupsId == id).FirstOrDefault();
            if (groups == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(groups);
        }

        [HttpPost]

        public IActionResult Add(Group groups)
        {
            Context.Groups.Add(groups);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Group groups)
        {
            Context.Groups.Update(groups);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Group? groups = Context.Groups.Where(x => x.GroupsId == id).FirstOrDefault();
            if (groups == null)
            {
                return BadRequest("Not Found");
            }
            Context.Groups.Remove(groups);
            Context.SaveChanges();
            return Ok();
        }
    }
}
