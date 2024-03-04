namespace ProGestor.Common.Entities;

public class Invoice:BaseEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public string DescriptionProject { get; set; }
    public string Amount { get; set; }
    public string PaymentType { get; set; }
    public bool Status { get; set; }

    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
    public string ModifiedBy { get; set; }
    
}