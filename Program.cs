using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

//IConfiguration configuration = builder.Configuration;
//string myValue = configuration["MyKey"] ?? "DefaultValue";
var app = builder.Build();

//var logger = app.Services.GetRequiredService<ILogger<Program>>();
//logger.LogInformation(myValue);
//app.MapGet("/", () => $"Hello World");
//To have your custom default files
//DefaultFilesOptions defaultFilesOptions = new();
//defaultFilesOptions.DefaultFileNames.Clear();
//defaultFilesOptions.DefaultFileNames.Add("foo.html");

//app.UseDefaultFiles(defaultFilesOptions);
////app.UseDefaultFiles(); //renders index.html or default.html file by default from wwwroot folder
//app.UseStaticFiles(); //To serve images in wwwroot folder

FileServerOptions fileServerOptions = new();
fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
app.UseFileServer(fileServerOptions); //combines both UseDefaultFiles and UseStaticFiles in one.


//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Hello from First middleWare");
//    await next();
//});

app.Run();
