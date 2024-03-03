using System.Security.Claims;
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
        var claimsIdentity = (ClaimsIdentity)User.Identity!;
        var actualUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        
        var getProjectList = new ProjectViewModel()
        {
            ProjectTypes = _projectTypeRepository.GetAll().Result.ToList(),
            StatusProjects = _statusProjectRepository.GetAll().Result.ToList(),
            Users = _userManager.Users.Where(x => x.Id != actualUser!.Value).ToList()
        };

        return View(getProjectList);
    }

    [HttpGet]
    public async Task<ActionResult> UpdateStatusProject(int projectId)
    {

        TempData["projectId"] = projectId;
        var listOfStatus = await _statusProjectRepository.GetAll();
        var getStatus = new ProjectViewModel
        {
            StatusProjects = listOfStatus.ToList()
        };

        return PartialView("_UpdateStatusProject", getStatus);
    }
    
    
    [HttpPost]
    public async Task<ActionResult> UpdateStatusProject(int projectId, Project project)
    {

        int projectCode = Convert.ToInt32(TempData["projectId"]);

        var projectUpdate = await _projectRepository.GetById(projectCode);

        projectUpdate.StatusProjectId = projectId;

        var result = await _projectRepository.Update(projectUpdate);

        if (result)
        {
            return RedirectToAction("Index");
        }
        
        return BadRequest();
    }

    [HttpGet]
    public async Task<ActionResult> UpdateDateTime(int projectId)
    {
        TempData["ProjectId"] = projectId;
        var getProject = await _projectRepository.GetById(projectId);

        var getFirstProject = new ProjectViewModel()
        {
            DateProjectStart = getProject.DateProjectStart,
            DateProjectEnd = getProject.DateProjectEnd
        };

        return PartialView("_UpdateDateTime", getFirstProject);
    }

    [HttpPost]
    public async Task<ActionResult> UpdateDateTime(DateTime DateProjectStart, DateTime DateProjectEnd)
    {
        int projectId = Convert.ToInt32(TempData["ProjectId"]);

        var project = await _projectRepository.GetById(projectId);

        if (DateProjectStart.Year >=  DateTime.Now.Year)
        {
            project.DateProjectStart = DateProjectStart;
        }

        if (DateProjectEnd.Year >= DateTime.Now.Year)
        {
            project.DateProjectEnd = DateProjectEnd;
        }
        
        var isUpdate = await _projectRepository.Update(project);

        if (isUpdate)
        {
            return RedirectToAction("Index");
        }
        return BadRequest();


    }
    
    [HttpGet]
    public async Task<ActionResult> UpdateEstimation(int projectId)
    {
        TempData["ProjectId"] = projectId;
        var getProject = await _projectRepository.GetById(projectId);

        var getFirstProject = new ProjectViewModel
        {
            quoter = getProject.quoter,
        };

        return PartialView("_UpdateEstimation", getFirstProject);
    }

    [HttpPost]
    public async Task<ActionResult> UpdateEstimation(double amount)
    {
        var projectId = Convert.ToInt32(TempData["ProjectId"]);

        var getProject = await _projectRepository.GetById(projectId);

        if (amount > 0)
        {
           getProject.quoter = amount;
        }

        var result = await _projectRepository.Update(getProject);

        if (result)
        {
            return RedirectToAction("Index");
        }
        
        return BadRequest();
    }
    [HttpPost]
    public async Task<ActionResult> RemoveProject(int ProjectId)
    {

        var getProject = await _projectRepository.GetById(ProjectId);

        getProject.Status = false;

        var wasRemove = await _projectRepository.Update(getProject);

        if (wasRemove)
        {
            return new JsonResult(new { id = 1 });
        }

        return BadRequest();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddProject(Project project)
    {
        project.Status = true;
        if (project.UserId != null)
        {
            var addProject = await _projectRepository.Add(project);
            if (addProject)
            {
                return RedirectToAction("Index");
            }
        }
        else
        {
            return RedirectToAction("AddProject");
        }
        
        return BadRequest();

    }
    
}