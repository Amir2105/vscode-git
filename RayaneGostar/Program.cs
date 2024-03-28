using System.ComponentModel;
using System.Reflection.Metadata;
using System;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RayaneGostar.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

services.AddScoped<IPasswordHelper, PasswordHelper>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IUserRepository, UserRepository>();

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



builder.Services.AddDbContext<RDbContetx>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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
