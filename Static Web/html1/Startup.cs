using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace html1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (ctx, next) =>
            {
                using (var reader = new StreamReader(ctx.Request.Body, Encoding.UTF8))
                { 
                    var content = await reader.ReadToEndAsync();

                    Console.WriteLine(content);

                    ctx.Request.Method = "GET";

                    await next();
                }
            });
            
            app.UseDefaultFiles();

            app.UseStaticFiles();
        }
    }
}
