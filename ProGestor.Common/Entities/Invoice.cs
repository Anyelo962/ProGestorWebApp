namespace ProGestor.Common.Entities;

public class Invoice:BaseEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public string MaterialUsed { get; set; }
    public string LaborUsed { get; set; }
    public string OtherExpenses { get; set; }
}