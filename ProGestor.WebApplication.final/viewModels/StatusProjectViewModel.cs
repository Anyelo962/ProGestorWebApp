using ProGestor.Common.Entities;

namespace ProGestor.WebApplication.final.viewModels;

public class StatusProjectViewModel
{
    public List<StatusProject> StatusProjects = new List<StatusProject>();
    public int Id { get; set; }
    public string name { get; set; }
}