using Microsoft.AspNetCore.Mvc;
using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.WebApplication.final.viewModels;

namespace ProGestor.WebApplication.final.Areas.Admin.Controllers;

[Area("Admin")]
public class StatusProjectController : Controller
{
    private readonly IStatusProjectRepository _statusProjectRepository;

    public StatusProjectController(IStatusProjectRepository statusProjectRepository)
    {
        _statusProjectRepository = statusProjectRepository;
    }

    public async Task<IActionResult> Index()
    {
        var listStatus = await _statusProjectRepository.GetAll();
        var list = new StatusProjectViewModel()
        {
            StatusProjects = listStatus.ToList()
        };
        
        return View(list);
    }

    [HttpPost]
    public async Task<IActionResult> Add(StatusProject statusProject)
    {
        await _statusProjectRepository.Add(statusProject);
        return RedirectToAction("Index");
    }

    // [HttpPut]
    // public async Task<IActionResult> Update(int id, StatusProject statusProject)
    // {
    //
    //
    //     return View("");
    // }
    //
    //
    // [HttpDelete]
    // public async Task<IActionResult> Remove(int id)
    // {
    //
    //     return View("");
    // }
}