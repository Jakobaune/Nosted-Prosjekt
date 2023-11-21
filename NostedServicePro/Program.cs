using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NostedServicePro.Data;

namespace NostedServicePro;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Opprett en webapplikasjonsbygger
        var builder = WebApplication.CreateBuilder(args);

        // Endret tilkoblingsstrengen
        var connectionString =
            "Server=localhost;Database=nosteddb;User=root;Password=nosted123;Port=3306;SslMode=none;";

        // Legg til DbContext med MySQL-databasekontekst
        builder.Services.AddDbContext<ServiceProDbContex>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        // Legg til st�tte for Identity-tjenester
        builder.Services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ServiceProDbContex>();

        // Legg til st�tte for kontrollere med visninger
        builder.Services.AddControllersWithViews();

        // Legg til st�tte for sesjoner med en timeout på 30 minutter
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Bygg webapplikasjonen
        var app = builder.Build();

        // Konfigurer HTTP-forespørselspipelinen
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
            "default",
            "{controller=Account}/{action=Login}/{id?}");
        app.MapRazorPages();

        // Opprett Kestrel-server med tilpasset konfigurasjon for å fjerne Server-headeren
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
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
        }


        //Oppretter Admin bruker ved start

        using (var scope = app.Services.CreateScope())
        {
            var userManager =
                scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var UserName = "Admin";
            var email = "admin@admin.no";
            var password = "Admin123!";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser();
                user.UserName = UserName;
                user.Email = email;

                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        // Kjør webapplikasjonen
        app.Run();
    }
}