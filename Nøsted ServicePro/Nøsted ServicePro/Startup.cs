using Microsoft.AspNetCore.Builder;
using Nøsted_ServicePro.Controllers.ServiceRegistrering;
using System.Text.Json.Serialization;

namespace Nøsted_ServicePro
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");


                context.Response.Headers.Add("X-Frame-Options", "DENY");


                context.Response.Headers.Add("Referrer-Policy", "no - referrer");


                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");


                context.Response.Headers.Add("Content-Security",
                "default - src 'self';  " +
                "img-src 'self'; " +
                "font-src 'self' ;" +
                "style-src 'self' ;" +
                "script-src 'self';" +
                "connect-src 'self';");
                await next();
            });
        }
    }
}
