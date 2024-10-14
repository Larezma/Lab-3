using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public TrainingController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Training> training = Context.Training.ToList();
            return Ok(training);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Training? training = Context.Training.Where(x => x.Id == id).FirstOrDefault();
            if (training == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(training);
        }

        [HttpPost]

        public IActionResult Add(Training training)
        {
            Context.Training.Add(training);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Training training)
        {
            Context.Training.Update(training);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Training? training = Context.Training.Where(x => x.Id == id).FirstOrDefault();
            if (training == null)
            {
                return BadRequest("Not Found");
            }
            Context.Training.Remove(training);
            Context.SaveChanges();
            return Ok();
        }
    }
}
