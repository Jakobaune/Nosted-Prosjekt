using Loginnosted.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;


var builder = WebApplication.CreateBuilder(args);

// Endret tilkoblingsstrengen
var connectionString = "Server=localhost;Database=nosteddb;User=root;Password=nosted123;Port=3306;SslMode=none;";

builder.Services.AddDbContext<LoginnostedDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

// Oppdatert ruteoppsett for LoginController
app.MapControllerRoute(
    name: "login",
    pattern: "login/{action=Index}/{id?}",
    defaults: new { controller = "Login" });

app.MapControllerRoute(
    name: "service",
    pattern: "service/{action=Index}/{id?}",
    defaults: new { controller = "Service" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();