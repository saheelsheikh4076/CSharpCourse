using IdentityProject.Data;
using IdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 2;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = "582011921156-hrk485au76bnn2p529v6idtlk0eups4r.apps.googleusercontent.com";
        options.ClientSecret = "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";
    }).AddFacebook(options =>
    {
        options.AppId = "554063113440256";
        options.AppSecret = "3efbb73c4a5fb5c85b5f51f4c98c808e";
    }).AddTwitter(options =>
    {
        options.ConsumerKey = "5540631134";
        options.ConsumerSecret = "3efbb73c4a5fb5c85b5f51f";
    });
//builder.Services.AddDefaultIdentity<IdentityUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = false;
//    options.User.RequireUniqueEmail = false;
//    options.Password.RequiredLength = 2;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireDigit = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireUppercase = false;
//})
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddTransient<EmailService>();
builder.Services.AddTransient<IEmailSender,EmailService>();
builder.Services.AddMvc();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
