using Microsoft.AspNetCore.Mvc;

namespace ProGestor.WebApplication.final.Areas.Client.Controllers;

[Area("Client")]
public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}