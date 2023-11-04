using Loginnosted;
using Loginnosted.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;

// Opprett en webapplikasjonsbygger
var builder = WebApplication.CreateBuilder(args);

// Endret tilkoblingsstrengen
var connectionString = "Server=localhost;Database=nosteddb;User=root;Password=nosted123;Port=3306;SslMode=none;";

// Legg til DbContext med MySQL-databasekontekst
builder.Services.AddDbContext<ServiceProDbContex>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Legg til st�tte for Identity-tjenester
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ServiceProDbContex>();

// Legg til st�tte for kontrollere med visninger
builder.Services.AddControllersWithViews();

// Legg til st�tte for sesjoner med en timeout p� 30 minutter
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Bygg webapplikasjonen
var app = builder.Build();

// Konfigurer HTTP-foresp�rselspipelinen
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Legg til autentisering og autorisasjon
app.UseAuthentication();
app.UseAuthorization();

// Oppdatert ruteoppsett for LoginController og andre kontrollere
/*
app.MapControllerRoute(
    name: "Bruker",
    pattern: "bruker/{action=Registrering}/{id?}",
    defaults: new { controller = "Bruker" });

app.MapControllerRoute(
    name: "service",
    pattern: "service/{action=Registrer}/{id?}",
    defaults: new { controller = "Service" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");
app.MapRazorPages();

// Opprett Kestrel-server med tilpasset konfigurasjon    for � fjerne Server-headeren
WebHost.CreateDefaultBuilder(args)
    .ConfigureKestrel(c => c.AddServerHeader = false)
    .UseStartup<Startup>()
    .Build();

// Kj�r webapplikasjonen
app.Run();
