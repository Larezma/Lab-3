using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public TrainerController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Trainer> trainers = Context.Trainers.ToList();
            return Ok(trainers);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Trainer? trainer = Context.Trainers.Where(x => x.TrainerId == id).FirstOrDefault();
            if (trainer == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(trainer);
        }

        [HttpPost]

        public IActionResult Add(Trainer trainer)
        {
            Context.Trainers.Add(trainer);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Trainer trainer)
        {
            Context.Trainers.Update(trainer);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Trainer? trainer = Context.Trainers.Where(x => x.TrainerId == id).FirstOrDefault();
            if (trainer == null)
            {
                return BadRequest("Not Found");
            }
            Context.Trainers.Remove(trainer);
            Context.SaveChanges();
            return Ok();
        }
    }
}
