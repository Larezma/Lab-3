using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersScheduleController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public TrainersScheduleController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<TrainersSchedule> TrainersSchedules = Context.TrainersSchedules.ToList();
            return Ok(TrainersSchedules);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            TrainersSchedule? TrainersSchedules = Context.TrainersSchedules.Where(x => x.Id == id).FirstOrDefault();
            if (TrainersSchedules == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(TrainersSchedules);
        }

        [HttpPost]

        public IActionResult Add(TrainersSchedule TrainersSchedules)
        {
            Context.TrainersSchedules.Add(TrainersSchedules);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(TrainersSchedule TrainersSchedules)
        {
            Context.TrainersSchedules.Update(TrainersSchedules);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            TrainersSchedule? TrainersSchedules = Context.TrainersSchedules.Where(x => x.Id == id).FirstOrDefault();
            if (TrainersSchedules == null)
            {
                return BadRequest("Not Found");
            }
            Context.TrainersSchedules.Remove(TrainersSchedules);
            Context.SaveChanges();
            return Ok();
        }
    }
}