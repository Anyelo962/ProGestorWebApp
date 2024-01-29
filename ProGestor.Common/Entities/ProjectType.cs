namespace ProGestor.Common.Entities;

public class ProjectType:BaseEntity
{
    public string name { get; set; }
    public string description { get; set; }
    public ICollection<Project> Projects { get; set; }
}