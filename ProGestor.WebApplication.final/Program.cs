using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;
using ProGestor.Infraestruture.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProGestorDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<ProGestorDbContext>();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<IGenderRepository, GenderRepository>();
builder.Services.AddTransient<IStatusProjectRepository, StatusProjectRepository>();
builder.Services.AddTransient<IProjectTypeRepository, ProjectTypeRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ProGestorDbContext>()
    .AddDefaultUI();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=client}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();