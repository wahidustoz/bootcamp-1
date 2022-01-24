using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using register.Data;
using register.ViewModels;

namespace register.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly UserManager<AppUser> _userManager;

    public UserController(ILogger<UserController> logger, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    [Authorize(Roles = "superadmin")]
    [HttpGet]
    public async Task<IActionResult> Users(string query, int page = 1, int limit = 10)
    {
        var filteredUsers = string.IsNullOrWhiteSpace(query) 
        ? _userManager.Users
        : _userManager.Users.Where(u => u.Fullname == query || u.Email == query || u.PhoneNumber == query);

        var users = await filteredUsers
        .Skip((page - 1) * limit)
        .Take(limit)
        .Select(u => new UserViewModel
        {
            Fullname = u.Fullname,
            Phone = u.PhoneNumber,
            Email = u.Email,
            Username = u.UserName,
            Birthdate = u.Birthdate
        }).ToListAsync();

        var totalUsers = filteredUsers.Count();

        return View(new UsersViewModel()
        {
            Users = users,
            TotalUsers = totalUsers,
            Pages =  (int)Math.Ceiling(totalUsers / (double)limit),
            Page = page,
            Limit = limit
        });
    }
}