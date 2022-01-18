using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt.auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecretController : ControllerBase
{
    
    [Authorize]
    [HttpGet("[action]")]
    public IActionResult Secret()
    {
        return Ok("👌");
    }
}