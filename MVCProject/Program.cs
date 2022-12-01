using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddSingleton<IRollList, RollList>();
builder.Services.AddTransient<IStudent,StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//Login system

app.UseAuthorization();//Roles

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Students}/{id?}");

app.Run();
