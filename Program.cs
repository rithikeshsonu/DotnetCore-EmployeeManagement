using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(); // Enables MVC 

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
