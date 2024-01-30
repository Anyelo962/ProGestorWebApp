using ProGestor.Common.Entities;

namespace ProGestor.WebApplication.final.viewModels;

public class ProjectTypeViewModel
{
    public List<ProjectType> ProjectTypes = new List<ProjectType>();
    
    public string Name { get; set; }
    public string Description { get; set; }
}