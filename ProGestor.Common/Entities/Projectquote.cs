using ProGestor.Common.Entities;

namespace ProGestor.Common.Entities;

public class Projectquote: BaseEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public double MaterialEstimation { get; set; }
    public double LaborEstimation { get; set; }
    public double OtherExpenses { get; set; }
}