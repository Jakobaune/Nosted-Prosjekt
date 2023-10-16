using Loginnosted;
using Loginnosted.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Endret tilkoblingsstrengen
var connectionString = "Server=localhost;Database=nosteddb;User=root;Password=nosted123;Port=3306;SslMode=none;";

builder.Services.AddDbContext<ServiceProDbContex>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
    pattern: "login/{action=Registrering}/{id?}",
    defaults: new { controller = "Bruker" });

app.MapControllerRoute(
    name: "service",
    pattern: "service/{action=Index}/{id?}",
    defaults: new { controller = "Service" });



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "sjekkliste",
    pattern: "sjekkliste/{action=VisSjekklisteElement}/{id?}",
    defaults: new { controller = "Sjekkliste" });


WebHost.CreateDefaultBuilder(args)
    .ConfigureKestrel(c => c.AddServerHeader=false)
    .UseStartup<Startup>()
    .Build();


app.Run();