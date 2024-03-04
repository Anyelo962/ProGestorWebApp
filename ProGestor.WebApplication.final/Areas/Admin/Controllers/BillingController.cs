using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.WebApplication.final.viewModels;

namespace ProGestor.WebApplication.final.Areas.Admin.Controllers;

[Area("Admin")]
public class BillingController : Controller
{

    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectTypeRepository _projectTypeRepository;
    private readonly IStatusProjectRepository _statusProjectRepository;
    private readonly UserManager<User> _userManager;

    public BillingController(IInvoiceRepository repository, IProjectRepository projectRepository, IProjectTypeRepository projectTypeRepository, IStatusProjectRepository statusProjectRepository, UserManager<User> userManager)
    {
        this._invoiceRepository = repository;
        _projectRepository = projectRepository;
        _projectTypeRepository = projectTypeRepository;
        _statusProjectRepository = statusProjectRepository;
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var getAll = await _invoiceRepository.GetAll();
        
        var getProjectList = new InvoiceViewModel()
        {
            Users = _userManager.Users.ToList(),
            Invoices = getAll.ToList()
            
        };


        return View();
    }


    [HttpGet]
    public async Task<ActionResult> AddBilling()
    {
        var getProjectList = new InvoiceViewModel()
        {
            Users = _userManager.Users.ToList()
        };
        
        return View(getProjectList);
    }
    [HttpPost]
    public async Task<ActionResult> AddBilling(Invoice invoice)
    {
       var result = await _invoiceRepository.Add(invoice);

       if (result)
       {
           return null;
       }

       return NotFound();
    }
}