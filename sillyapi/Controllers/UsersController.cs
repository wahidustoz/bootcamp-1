using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using sillyapi.Dto;

namespace sillyapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public static List<NewUser> Users { get; set; } = new List<NewUser>();
        
        [HttpGet]
        [Route("{lastname}")]
        public IActionResult Get([FromQuery]string firstname, [FromRoute]string lastname) 
        {
            if(string.IsNullOrWhiteSpace(firstname))
            {
                return Ok(Users);
            }

            return Ok(Users.Where(u => u.Firstname == firstname));
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Create([FromBody]NewUser user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("One or more fields are in wrong format.");
            }

            Users.Add(user);

            return Ok(Users);
        }

        [HttpDelete]
        [Route("{firstname}")]
        public IActionResult Delete([FromRoute]string lastname)
        {
            if(string.IsNullOrWhiteSpace(lastname) || !Users.Any(u => u.Lastname == lastname))
            {
                return BadRequest($"{lastname} does not exist!");
            }

            Users.Remove(Users.FirstOrDefault(u => u.Lastname == lastname));

            return Ok(Users);
        }
    }
}