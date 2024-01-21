// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using ProGestor.Common.Entities;
//
// namespace ProGestor.WebApplication.final.Data;
//
// public class ProGestorDbContext: DbContext
// {
//     public ProGestorDbContext(DbContextOptions<ProGestorDbContext> contextOptions):base(contextOptions)
//     {
//         
//     }
//     
//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//         optionsBuilder.UseSqlServer("server=localhost; database=ProGestorDb; user=sa; password=someThingComplicated1234;Trust Server Certificate=True;");
//     }
//     
//     public DbSet<Address> Addresses { get; set; }
//     public DbSet<City> Cities { get; set; }
//     public DbSet<Gender> Genders { get; set; }
// }