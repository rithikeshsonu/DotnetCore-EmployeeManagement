using EmployeeManagement.DAL.Implementations;
using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection"))); //EFCore

builder.Services.AddMvc(); // Enables MVC 
//builder.Services.AddMvc().AddXmlSerializerFormatters(); // Enables MVC 

builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>(); //Single instance. Used throught the app lifecycle


var app = builder.Build();

app.UseStaticFiles();
// Enable routing and MVC
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute(); // Uses {controller=Home}/{action=Index}/{id?}
    endpoints.MapControllers(); // For API controllers
});

//app.MapGet("/", () => $"Hello World");

app.Run();
