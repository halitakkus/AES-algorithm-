using AES.WebMVC.Services.Rest.Base;
using app.WebMVC.Services.Rest.Base;
using Application.Core.Configuration.Context;
using Application.Core.Configuration.Environment;
using Application.Core.Extensions;
using Asmin.WebMVC.Services.Rest.IncomingVisitorService;
using Asmin.WebMVC.Services.Rest.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asmin.WebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ApplicationConfigurationContext = new ApplicationConfigurationContext(new EnvironmentService());
        }

        public IConfiguration Configuration { get; }
        public IApplicationConfigurationContext ApplicationConfigurationContext { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddSession();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddTransient<IHttpService, HttpService>();

            services.AddSingleton<IUserApiService, UserApiService>();

            services.AddHttpClient();

            // Register core module. 🎉
            services.AddCoreModule();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

           

            // Use exception middleware. 🎉
            app.UseMVCExceptionMiddleware("/Home/Error");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "Admin",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
