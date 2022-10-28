

using MainProject.Models;

var builder = WebApplication.CreateBuilder();


builder.Services.AddRazorPages();
builder.Services.AddSingleton<NewTestClass>();
//Transient service creates new instance for every request
var app = builder.Build();
//Following code is a pipeline

app.MapRazorPages();
//app.MapGet("/", () => "hello from web app users ");
app.Run();