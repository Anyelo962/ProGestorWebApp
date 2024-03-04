namespace ProGestor.Common.Entities;

public class PaymentAdvance: BaseEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public DateTime PaymentDate { get; set; }
    public double AmountPaid { get; set; }
    public double RemainingBalance { get; set; }
    public bool Status { get; set; }

}