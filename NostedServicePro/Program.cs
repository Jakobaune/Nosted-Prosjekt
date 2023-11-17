using NostedServicePro;
using NostedServicePro.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;

namespace NostedServicePro
{

    public class Program
    {

        public static async Task Main(string[] args)
        {
            // Opprett en webapplikasjonsbygger
            var builder = WebApplication.CreateBuilder(args);

            // Endret tilkoblingsstrengen
            var connectionString = "Server=localhost;Database=nosteddb;User=root;Password=nosted123;Port=3306;SslMode=none;";

            // Legg til DbContext med MySQL-databasekontekst
            builder.Services.AddDbContext<ServiceProDbContex>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Legg til st�tte for Identity-tjenester
            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
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


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");
            app.MapRazorPages();

            // Opprett Kestrel-server med tilpasset konfigurasjon    for � fjerne Server-headeren
            WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel(c => c.AddServerHeader = false)
                .UseStartup<Startup>()
                .Build();

            
            //Oppretter rollene Admin og Mekaniker ved start
            using (var scope = app.Services.CreateScope())
            {
                var roleManager =
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Mekaniker" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }


            //Oppretter Admin bruker ved start

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                string UserName = "Admin";
                string email = "admin@admin.no";
                string password = "Admin123!";

                if(await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = UserName;
                    user.Email = email;

                    await userManager.CreateAsync(user,password);

                    await userManager.AddToRoleAsync(user, "Admin");
                }

    
            }

            // Kj�r webapplikasjonen
            app.Run();
        }
    }
}
