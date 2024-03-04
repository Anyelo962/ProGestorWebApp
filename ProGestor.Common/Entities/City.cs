namespace ProGestor.Common.Entities;

public class City: BaseEntity
{
    public int Id { get; set; }
    public string name { get; set; }
    public bool Status { get; set; }

    public ICollection<Address> Addresses { get; set; }
    public ICollection<User> Users { get; set; }
}