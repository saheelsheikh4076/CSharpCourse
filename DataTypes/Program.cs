using Services;

using MainProject.Models;
using Repositories;

var builder = WebApplication.CreateBuilder();


builder.Services.AddRazorPages();
builder.Services.AddSingleton<NewTestClass>();
builder.Services.AddSingleton<IRollList, RollList>();
//Transient service creates new instance for every request
var app = builder.Build();
//Following code is a pipeline

app.MapRazorPages();
//app.MapGet("/", () => "hello from web app users ");
app.Run();