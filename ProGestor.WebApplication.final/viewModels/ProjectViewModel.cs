using ProGestor.Common.Entities;
using Project = Microsoft.Build.Evaluation.Project;

namespace ProGestor.WebApplication.final.viewModels;

public class ProjectViewModel
{
    public List<Project> Projects = new List<Project>();
    public List<User> Users = new List<User>();
    public List<ProjectType> ProjectTypes = new List<ProjectType>();
    public List<StatusProject> StatusProjects = new List<StatusProject>();
    
    public string UserId { get; set; }
    public int ProjectTypeId { get; set; }
    public DateTime DateProjectStart { get; set; }
    public DateTime DateProjectEnd { get; set; }
    public int StatusProjectId { get; set; }
    public double quoter { get; set; } 

}