using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProGestor.Common.Entities;

namespace ProGestor.Infraestruture.Data;

public class ProGestorDbContext: IdentityDbContext<User>
{
    public ProGestorDbContext(DbContextOptions<ProGestorDbContext> contextOptions):base(contextOptions)
    {
        
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Gender> Genders { get; set; }
}