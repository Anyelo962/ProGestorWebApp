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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<StatusProject> StatusProjects { get; set; }
    public DbSet<ProjectType> ProjectTypes { get; set; }
    public DbSet<ActivitySchedule> ActivitySchedules { get; set; }
    public DbSet<CivilEngineeringDesigns> CivilEngineeringDesigns { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<PaymentAdvance> PaymentAdvances { get; set; }
    public DbSet<Projectquote> Projectquotes { get; set; }
    public DbSet<ProjectTracking> ProjectTrackings { get; set; }
    
    public DbSet<Project> Projects { get; set; }
}