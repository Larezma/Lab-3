using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogsController : ControllerBase
    {
        public VitalityMasteryContext Context { get; }

        public DialogsController(VitalityMasteryContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            List<Dialog> dialogs = Context.Dialogs.ToList();
            return Ok(dialogs);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Dialog? dialogs = Context.Dialogs.Where(x => x.DialogsId == id).FirstOrDefault();
            if (dialogs == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(dialogs);
        }

        [HttpPost]

        public IActionResult Add(Dialog dialogs)
        {
            Context.Dialogs.Add(dialogs);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Dialog dialogs)
        {
            Context.Dialogs.Update(dialogs);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public IActionResult DeleteById(int id)
        {
            Dialog? dialogs = Context.Dialogs.Where(x => x.DialogsId == id).FirstOrDefault();
            if (dialogs == null)
            {
                return BadRequest("Not Found");
            }
            Context.Dialogs.Remove(dialogs);
            Context.SaveChanges();
            return Ok();
        }
    }
}