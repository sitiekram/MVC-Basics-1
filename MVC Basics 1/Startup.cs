using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using MVC_Basics_1.Data;
using Microsoft.AspNetCore.Identity;
using MVC_Basics_1.Areas.Identity;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using MVC_Basics_1.Models.Interfaces;
//using MVC_Basics_1.Models.Services;

namespace MVC_Basics_1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
       public IConfiguration Configuration { get; set; }
       
       public Startup(IConfiguration configuration)
        { Configuration = configuration; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddScoped<IPersonService, PersonService>();
            //services.AddScoped<ICityService, CityService>();
            //services.AddScoped<ILanguageService, LanguageService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
                .AddV8();
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();

            services.AddRazorPages();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseReact(config =>
            {
                //config.AddScript("file");
            }
           );
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "Default",
                     pattern: "{controller=Home}/{action=Index}/{id?}"
                     );
                endpoints.MapControllerRoute(
                    name: "Doctor",
                    pattern: "FeverCheck",
                    defaults: new { controller = "Doctor", action = "Patient" });
                endpoints.MapControllerRoute(
                    name: "Guess",
                    pattern: "GuessingGame",
                    defaults: new { controller = "Guess", action = "Index" });
                endpoints.MapRazorPages();
            });
        }
    }
}
