using Microsoft.AspNetCore.Mvc;

namespace ProGestor.WebApplication.final.Areas.Admin.Controllers;

[Area("Admin")]
public class GenderController : Controller
{

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}