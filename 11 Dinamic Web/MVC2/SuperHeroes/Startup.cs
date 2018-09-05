using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperHeroes.DataAccess;
using SuperHeroes.Models;

namespace SuperHeroes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IRepository<SuperHero>, MemoryRepository>(); // usa sempre la stessa istanza
            services.AddSingleton<IRepository<Villain>, MemoryRepository>();
            //services.AddScoped<IRepository<SuperHero>, MemoryRepository>();
            //services.AddTransient<IRepository<SuperHero>, MemoryRepository>();

            //services.AddDbContext<SqlRepository>(options =>
            //{
            //    options.UseSqlServer();
            //}));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=SuperHeroes}/{action=List}/{id?}");
            });
        }
    }
}
