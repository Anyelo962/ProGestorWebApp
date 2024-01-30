using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.WebApplication.final.viewModels;

namespace ProGestor.WebApplication.final.Areas.Admin.Controllers;

[Area("Admin")]
public class ProjectTypeController : Controller
{

    private readonly IProjectTypeRepository _projectTypeRepository;

    public ProjectTypeController(IProjectTypeRepository projectTypeRepository)
    {
        _projectTypeRepository = projectTypeRepository;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var projectTypeList = await _projectTypeRepository.GetAll();
        var projectType = new ProjectTypeViewModel()
        {
            ProjectTypes = projectTypeList.ToList()
        };
        
        return View(projectType);
    }


    [HttpPost]
    public async Task<IActionResult> Add(ProjectType projectType)
    {
        if (String.IsNullOrEmpty(projectType.name) || String.IsNullOrEmpty(projectType.description))
        {
            return Json(new { id = 1, message = "Asegure de completar todos los campos" });
        }
        
        var addType = await _projectTypeRepository.Add(projectType);

        if (addType)
        {
            return RedirectToAction("Index");
        }

        else return BadRequest();

    }

    [HttpGet]
    public async Task<IActionResult> UpdateType(int id)
    {
        var getType = await _projectTypeRepository.GetById(id);
        
        TempData["Id"] = getType.Id;

        var type = new ProjectTypeViewModel()
        {
            Name = getType.name,
            Description = getType.description
        };

        return PartialView("_UpdateType", type);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateType(ProjectType projectType)
    {
        int getId = Convert.ToInt32(TempData["Id"]);

        var update = await _projectTypeRepository.GetById(getId);

        update.name = projectType.name;
        update.description = projectType.description;

        var isTrue = await _projectTypeRepository.Update(update);

        if (isTrue)
        {
            return RedirectToAction("Index");
        }
        
        return BadRequest();
    }



    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        var getType = await _projectTypeRepository.Remove(id);

        if (getType)
        {
            return Json(new { id = 1, message = "Se ha eliminado con exito" });
        }
        return Json(new { id = 2, message = "No se ha podido eliminar el registro" });
    }
    
    
}