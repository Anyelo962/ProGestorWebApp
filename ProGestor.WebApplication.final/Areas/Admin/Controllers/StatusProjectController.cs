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
        if (String.IsNullOrEmpty(statusProject.name) || String.IsNullOrEmpty(statusProject.name))
        {
            return Json(new { id = 1, message = "Asegurese de completar todos los campos" });
        }
        
        await _statusProjectRepository.Add(statusProject);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateStatus(int id)
    {
        var getStatus  = await _statusProjectRepository.GetById(id);

        TempData["Id"] = getStatus.Id;
        var getModel = new StatusProjectViewModel()
        {
            Id = getStatus.Id,
            name = getStatus.name
        };
        
        return PartialView("_UpdateStatus",getModel);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(StatusProject statusProject)
    {
        var Id = Convert.ToInt32(TempData["Id"].ToString());
        var getById = await _statusProjectRepository.GetById(Id);

        getById.name = statusProject.name;
        var update = await _statusProjectRepository.Update(getById);
        
        if (update)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return BadRequest();
        }
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        var remove = await _statusProjectRepository.Remove(id);

        if (remove)
        {
            return Json(new { id = 1 });
        }
        
        
        return Json(new { id = 2 });
    }
}