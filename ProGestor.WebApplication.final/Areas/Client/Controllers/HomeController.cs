using Microsoft.AspNetCore.Mvc;

namespace ProGestor.WebApplication.final.Areas.Client.Controllers;

[Area("Client")]
public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {

        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("MainPage");
        }
        
        return View();
    }

    public IActionResult MainPage()
    {
        return View();
    }
}