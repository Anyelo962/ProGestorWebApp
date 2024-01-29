using Microsoft.AspNetCore.Mvc;

namespace ProGestor.WebApplication.final.Areas.Admin.Controllers;


[Area("Admin")]
public class ProjectController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}