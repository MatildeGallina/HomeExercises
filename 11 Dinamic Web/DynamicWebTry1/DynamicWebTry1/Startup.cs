using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicWebTry1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                // posso eseguire del codice in andata
                if (context.Request.Path.Value.Contains("1mw"))
                    await context.Response.WriteAsync("Solo primo middleware!");
                else if (context.Request.Path.Value.Contains("2mw"))
                    await next(); // aspetto il secondo mw
                else if (context.Request.Path.Value.Contains("home"))
                    await next();

                // posso eseguire del codice in ritorno
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("2mw"))
                    await context.Response.WriteAsync("Secondo middleware raggiunto!");
                else if (context.Request.Path.Value.Contains("home"))
                    await next();
            });

            app.Use(async (context, next) =>
            {
                var values = new[] { 10, 20, 45, 7, 25 };

                var html = "<!DOCTYPE html>" +
                    "<html>" +
                        "<head>" +
                            "<title>Dynamic Web Try 1</title>" +
                        "</head>" +
                        "<body>" +
                            "<h1>Home!</h1>" +
                            "<table>" +
                                "<thead>" +
                                    "<tr>" +
                                        "<th>Table title</th>" +
                                    "</tr>" +
                                "</thead>" +
                                "<tbody>" +
                                    "<tr>";

                foreach(var v in values)
                {
                    html += $"<td>{v}</td>";
                }

                html +=             "</tr>" +
                                "</tbody>" +
                            "</table>" +
                        "</body>" +
                    "</html>";

                await context.Response.WriteAsync(html);
            });
        }
    }
}
