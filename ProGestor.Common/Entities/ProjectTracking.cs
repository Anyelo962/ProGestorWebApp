namespace ProGestor.Common.Entities;

public class ProjectTracking:BaseEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public string ActivityPerformed { get; set; }
    public string ProjectStatus { get; set; }
    public bool Status { get; set; }

}