namespace ProGestor.Common.Entities;

public class CivilEngineeringDesigns: BaseEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public string DesignName { get; set; }
    public byte [] Document { get; set; }
    public bool Status { get; set; }

}