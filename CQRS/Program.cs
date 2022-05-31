using System.Reflection;
using CQRS.Data;
using CQRS.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

/* services.AddScoped<IPlayersService, PlayersService>(); */
builder.Services.AddScoped<ISchoolsService, SchoolsService>();

/* services.AddMediatR(Assembly.GetExecutingAssembly());*/
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


// Scaffold - DbContext - Connection "Server=HARUNA; Database= Schools; Trusted_Connection=True; MultipleActiveResultSets=true;" -Provider Microsoft.EntityFrameworkCore.SqlServer - OutputDir "Models" - ContextDir "Data" - Context "SchoolDbContext"


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
