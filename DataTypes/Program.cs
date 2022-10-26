

var builder = WebApplication.CreateBuilder();


builder.Services.AddRazorPages();
var app = builder.Build();
//Following code is a pipeline

app.MapRazorPages();
//app.MapGet("/", () => "hello from web app users ");
app.Run();