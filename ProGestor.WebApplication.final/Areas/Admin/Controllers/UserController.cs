using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProGestor.Common.Entities;

namespace ProGestor.WebApplication.final.Areas.Admin.Controllers;


[Area("Admin")]
public class UserController : Controller
{

    private readonly UserManager<User> _userManager;

    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity!;
        var actualUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        var test = User.Claims.ToList();
        var userList = _userManager.Users
            .Include(x => x.Gender)
            .Include(c => c.City)
            .Where(x => x.Id != actualUser!.Value).ToList();
        
        return View(userList);
    }
}