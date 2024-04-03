using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RayaneGostar.InfraData.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme=CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(Options =>
{
    Options.LoginPath="/login";
    Options.LogoutPath="/log-out";
    Options.ExpireTimeSpan= TimeSpan.FromMinutes(43200);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
