namespace ProGestor.Common.Entities;

public class Project: BaseEntity
{
    public string UserId { get; set; }
    public User User { get; set; }
    public int ProjectTypeId { get; set; }
    public ProjectType ProjectType { get; set; }
    public DateTime DateProjectStart { get; set; }
    public DateTime DateProjectEnd { get; set; }
    public int StatusProjectId { get; set; }
    public StatusProject StatusProject { get; set; }
    public double quoter { get; set; } 
}