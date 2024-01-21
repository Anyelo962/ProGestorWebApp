using Microsoft.AspNetCore.Identity;

namespace ProGestor.Common.Entities;

public class User: IdentityUser
{
    public string lastName { get; set; }
    public int genderId { get; set; }
    public Gender Gender { get; set; }
    public string numberPhone { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}