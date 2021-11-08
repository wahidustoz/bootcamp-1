using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using tasks.Model;

namespace tasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult CreateTask([FromBody]NewTask newTask)
        {
            return Ok(newTask);
        }

        [HttpGet]
        public IActionResult QueryTasks([FromQuery]TaskQuery query)
        // public IActionResult QueryTasks([FromQuery]string title, [FromQuery]string id)
        {
            return Ok(query);
        }
    }
}