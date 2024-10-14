using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTrainingController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public UserTrainingController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<UserTraining> UserTrainings = Context.UserTrainings.ToList();
            return Ok(UserTrainings);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            UserTraining? UserTrainings = Context.UserTrainings.Where(x => x.Id == id).FirstOrDefault();
            if (UserTrainings == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(UserTrainings);
        }

        [HttpPost]

        public IActionResult Add(UserTraining UserTrainings)
        {
            Context.UserTrainings.Add(UserTrainings);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(UserTraining UserTrainings)
        {
            Context.UserTrainings.Update(UserTrainings);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            UserTraining? UserTrainings = Context.UserTrainings.Where(x => x.Id == id).FirstOrDefault();
            if (UserTrainings == null)
            {
                return BadRequest("Not Found");
            }
            Context.UserTrainings.Remove(UserTrainings);
            Context.SaveChanges();
            return Ok();
        }
    }
}
