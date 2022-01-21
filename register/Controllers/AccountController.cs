using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using register.Data;
using register.ViewModels;

namespace register.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signinManager;
    private readonly ILogger<AccountController> _logger;

    public AccountController(
        ILogger<AccountController> logger,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signinManager)
    {
        _userManager = userManager;
        _signinManager = signinManager;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Signup(string returnUrl) 
        => View(new SignupViewModel() { ReturnUrl = returnUrl ?? string.Empty });

    [HttpPost]
    public async Task<IActionResult> Signup(SignupViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        if(await _userManager.Users.AnyAsync(u => u.Email == model.Email))
        {
            ModelState.AddModelError("Email", "Email already exists.");
            return View(model);
        }

        if(await _userManager.Users.AnyAsync(u => u.PhoneNumber == model.Phone))
        {
            ModelState.AddModelError("Phone", "Phone already exists.");
            return View(model);
        }

        var user = new AppUser()
        {
            Fullname = model.Fullname,
            Email = model.Email,
            PhoneNumber = model.Phone,
            Birthdate = model.Birthdate,
            UserName = model.Email.Substring(0, model.Email.IndexOf('@'))
        };

        await _userManager.CreateAsync(user, model.Password);
        await _userManager.AddToRoleAsync(user, "student");

        return LocalRedirect($"/account/signin?returnUrl={model.ReturnUrl}");
    }

    [HttpGet]
    public IActionResult Signin(string returnUrl) 
        => View(new SigninViewModel() { ReturnUrl = returnUrl ?? string.Empty });

    [HttpPost]
    public async Task<IActionResult> Signin(SigninViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        var user = _userManager.Users.FirstOrDefault(u => u.Email == model.Email);

        var result = await _signinManager.PasswordSignInAsync(user, model.Password, false, false);
        if(result.Succeeded)
        {
            return LocalRedirect(model.ReturnUrl ?? "/");
        }

        return BadRequest(result.IsNotAllowed);
    }
}