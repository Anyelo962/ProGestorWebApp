namespace ProGestor.Common.Entities;

public class ActivitySchedule: BaseEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double EstimatedCost { get; set; }
    
    public bool Status { get; set; }

    
}