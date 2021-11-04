using System.Reflection.Metadata;
using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using accounts.Data;
using accounts.Entity;
using accounts.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace accounts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly ApplicationDbContext _context;

        public AccountsController(ILogger<AccountsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.Select(u => new UserWithoutPassword()
            {
                Firstname = u.Firstname,
                Lastname = u.Lastname,
                Middlename = u.Middlename,
                Phone = u.Phone,
                Email = u.Email,
                Username = u.Username,
                CreatedAt = u.CreatedAt,
                ModifiedAt = u.ModifiedAt,
                Id = u.Id
            }).ToListAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute]Guid id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if(user is default(User))
            {
                return NotFound($"User with ID {id} not found");
            }

            return Ok(user);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser([FromBody]NewUser newUser)
        {
            if(!ModelState.IsValid)
            {
                _logger.LogInformation($"Model validation failed for {JsonSerializer.Serialize(newUser)}");
                return BadRequest("User properties are not valid.");
            }

            var user = new User(
                firstname: newUser.Firstname,
                lastname: newUser.Lastname,
                middlename: newUser.Middlename,
                phone: newUser.Phone,
                email: newUser.Email,
                password: newUser.Password);

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"New user added with ID: {user.Id}");

                return Ok();
            }
            catch(Exception e)
            {
                _logger.LogWarning($"Error occured while saving user to DB:\n{e.Message}");
                return StatusCode(500, new { errorMessage = e.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdatedUser updatedUser)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if(user is default(User))
            {
                return NotFound($"User with ID {id} not found");
            }

            if(!_updatedUserValid(updatedUser))
            {
                return BadRequest("You should change at least one property.");
            }

            user.Firstname = updatedUser.Firstname ?? user.Firstname;
            user.Lastname = updatedUser.Lastname ?? user.Lastname;
            user.Middlename = updatedUser.Middlename ?? user.Middlename;
            user.Email = updatedUser.Email ?? user.Email;
            user.Phone = updatedUser.Phone ?? user.Phone;
            user.Username = updatedUser.Username ?? user.Username;
            user.Password = updatedUser.Password ?? user.Password;

            user.ModifiedAt = DateTimeOffset.UtcNow;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool _updatedUserValid(UpdatedUser updatedUser)
        {
            return !(updatedUser.Firstname == null &&
                    updatedUser.Phone == null &&
                    updatedUser.Email == null &&
                    updatedUser.Lastname == null &&
                    updatedUser.Middlename == null &&
                    updatedUser.Password == null &&
                    updatedUser.Username == null);
        }
    }
}