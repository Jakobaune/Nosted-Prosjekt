using Microsoft.AspNetCore;
using Nøsted_ServicePro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Custom route for RegistrereServiceController
app.MapControllerRoute(
    name: "registrereService",
    pattern: "{area=}/{controller=ServiceRegistrering}/{action=IndexRS}/{id?}");

WebHost.CreateDefaultBuilder(args)
    .ConfigureKestrel(c => c.AddServerHeader = false)
    .UseStartup<Startup>()
    .Build();



app.Run();


