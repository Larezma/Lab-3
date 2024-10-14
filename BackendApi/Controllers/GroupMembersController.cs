using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMembersController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public GroupMembersController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<GroupMember> groupMembers = Context.GroupMembers.ToList();
            return Ok(groupMembers);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            GroupMember? groupMembers = Context.GroupMembers.Where(x => x.GroupsId == id).FirstOrDefault();
            if (groupMembers == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(groupMembers);
        }

        [HttpPost]

        public IActionResult Add(GroupMember groupMembers)
        {
            Context.GroupMembers.Add(groupMembers);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(GroupMember groupMembers)
        {
            Context.GroupMembers.Update(groupMembers);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            GroupMember? groupMembers = Context.GroupMembers.Where(x => x.GroupsId == id).FirstOrDefault();
            if (groupMembers == null)
            {
                return BadRequest("Not Found");
            }
            Context.GroupMembers.Remove(groupMembers);
            Context.SaveChanges();
            return Ok();
        }
    }
}
