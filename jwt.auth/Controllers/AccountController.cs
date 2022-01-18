using jwt.auth.Models;
using jwt.auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace jwt.auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly JwtService _jwt;

    public AccountController(JwtService jwt)
    {
        _jwt = jwt;
    }

    [HttpPost("[action]")]
    public IActionResult Login(LoginModel model)
    {
        var token = _jwt.GenerateToken(model.Username, "user");
        return Ok(new {
            token = token,
            user = model.Username
        });
    }
}