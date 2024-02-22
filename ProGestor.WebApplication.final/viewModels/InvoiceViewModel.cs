using ProGestor.Common.Entities;
using Project = Microsoft.Build.Evaluation.Project;

namespace ProGestor.WebApplication.final.viewModels;

public class InvoiceViewModel
{
    public List<Project> Projects = new List<Project>();
    public List<Invoice> Invoices = new List<Invoice>();
    public List<User> Users = new List<User>();

    public Project Project { get; set; }
    public List<string> PaymentMethod = new List<string>()
    {
        "Efectivo",
        "Transferencia"
    };
    public string DescriptionProject { get; set; }
    public string Amount { get; set; }
    public string PaymentType { get; set; }
}