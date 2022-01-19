using Microsoft.AspNetCore.Mvc;
using register.ViewModels;

namespace register.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Signup() => View();

    [HttpPost]
    public IActionResult Signup(SignupViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        return Ok("👍");
    }
}