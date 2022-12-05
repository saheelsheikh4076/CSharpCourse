using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using MVCProject.Services;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")??string.Empty;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddDataProtection();
builder.Services.AddMvc();
builder.Services.AddSingleton<IRollList, RollList>();
builder.Services.AddTransient<IStudent,StudentServiceEF>();

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
