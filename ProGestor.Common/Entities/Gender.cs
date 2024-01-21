namespace ProGestor.Common.Entities;

public class Gender: BaseEntity
{
    public string name { get; set; }
    public ICollection<User> Users { get; set; }
}