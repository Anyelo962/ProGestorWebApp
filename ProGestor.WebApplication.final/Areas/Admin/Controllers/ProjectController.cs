using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.WebApplication.final.viewModels;

namespace ProGestor.WebApplication.final.Areas.Admin.Controllers;


[Area("Admin")]
public class ProjectController : Controller
{

    private readonly IProjectRepository _projectRepository;
    private readonly IProjectTypeRepository _projectTypeRepository;
    private readonly IStatusProjectRepository _statusProjectRepository;
    private readonly UserManager<User> _userManager;

    public ProjectController(IProjectRepository projectRepository, 
        IProjectTypeRepository projectTypeRepository, IStatusProjectRepository statusProjectRepository, UserManager<User> userManager)
    {
        _projectRepository = projectRepository;
        _projectTypeRepository = projectTypeRepository;
        _statusProjectRepository = statusProjectRepository;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _projectRepository.GetAllProject();
        return View(result);
    }


    [HttpGet]
    public async Task<IActionResult> AddProject()
    {
        var getProjectList = new ProjectViewModel()
        {
            ProjectTypes = _projectTypeRepository.GetAll().Result.ToList(),
            StatusProjects = _statusProjectRepository.GetAll().Result.ToList(),
            Users = _userManager.Users.ToList()
        };

        return View(getProjectList);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProject(Project project)
    {

        var addProject = await _projectRepository.Add(project);

        if (addProject)
        {
            return RedirectToAction("Index");
        }


        return BadRequest();

    }


    
    
}