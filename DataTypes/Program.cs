

var builder = WebApplication.CreateBuilder();



var app = builder.Build();


app.MapGet("/", () => "hello from web app");
app.Run();