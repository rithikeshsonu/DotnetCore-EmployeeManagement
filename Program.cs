var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
string myValue = configuration["MyKey"];
var app = builder.Build();

app.MapGet("/", () => $"Hello World! My secret value is: {myValue}");

app.Run();

