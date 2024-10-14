using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public ScheduleController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Schedule> schedules = Context.Schedules.ToList();
            return Ok(schedules);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Schedule? schedule = Context.Schedules.Where(x => x.ScheduleId == id).FirstOrDefault();
            if (schedule == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(schedule);
        }

        [HttpPost]

        public IActionResult Add(Schedule schedule)
        {
            Context.Schedules.Add(schedule);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Schedule schedule)
        {
            Context.Schedules.Update(schedule);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Schedule? schedule = Context.Schedules.Where(x => x.ScheduleId == id).FirstOrDefault();
            if (schedule == null)
            {
                return BadRequest("Not Found");
            }
            Context.Schedules.Remove(schedule);
            Context.SaveChanges();
            return Ok();
        }
    }
}
