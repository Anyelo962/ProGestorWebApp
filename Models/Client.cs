using Microsoft.AspNetCore.Identity;

namespace ProGestor.WebApplication.final.Models;

public class Client: IdentityUser
{
    public string name { get; set; }
    public string lastName { get; set; }
}