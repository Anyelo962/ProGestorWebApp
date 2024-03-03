namespace ProGestor.Common.Entities;

public class StatusProject: BaseEntity
{
    public StatusProject()
    {
        ProgProjects = new List<Project>();
    }
    public string name { get; set; }
    public bool Status { get; set; }
    public ICollection<Project> ProgProjects { get; set; }
}