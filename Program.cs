using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
string myValue = configuration["MyKey"] ?? "DefaultValue";
var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation(myValue);

app.MapGet("/", () => $"Hello World");

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello from First middleWare");
    await next();
});

app.Run();
