using EmployeeManagement.DAL.Implementations;
using EmployeeManagement.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(); // Enables MVC 
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>(); //Single instance. Used throught the app lifecycle

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
