using Microsoft.AspNetCore.Builder;

namespace Loginnosted
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

            // Legger til sikkerhetsheader-innstillinger for å forbedre nettapplikasjonens sikkerhet

            app.Use(async (context, next) =>
            {
                // Beskyttelse mot Cross-Site Scripting (XSS)
                context.Response.Headers.Add("X-Xss-Protection", "1");

                // Forhindrer clickjacking ved å begrense nettstedets visning i rammer
                context.Response.Headers.Add("X-Frame-Options", "DENY");

                // Kontrollerer hvilken referer-informasjon som sendes sammen med forespørselen
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");

                // Hindrer MIME-sniffing av nettleseren
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

                // Definerer innholdssikkerhetspolitikken for nettstedet
                context.Response.Headers.Add(
                    "Content-Security-Policy",
                    "default-src 'self'; " +
                    "font-src 'self'; " +
                    "style-src 'self' " +
                    "script-src 'self' " +
                    "frame-src 'self' " +
                    "connect-src 'self' ");
                await next();
            });
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}