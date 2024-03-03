namespace ProGestor.Common.Entities;

public class Address: BaseEntity
{
    public string name { get; set; }
    public string houseNumber { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public bool Status { get; set; }

}