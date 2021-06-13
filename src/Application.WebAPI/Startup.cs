using Application.Business.Extensions;
using Application.Core.Configuration.Context;
using Application.Core.Configuration.Environment;
using Application.Core.Extensions;
using Application.Packages.AOP.InterceptModule;
using Application.Packages.Hashing.AES.Extensions;
using Application.Packages.Hashing.SHA256.Extensions;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Application.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigurationContext = new ApplicationConfigurationContext(new EnvironmentService());
        }

        public IConfiguration Configuration { get; }
        private IApplicationConfigurationContext ConfigurationContext { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var executingAssembly = System.Reflection.Assembly.LoadFrom("..\\Application.Business\\bin\\Debug\\netcoreapp3.1\\Application.Business.dll");
            var interceptorModule = new AutofacInterceptorModule();

            interceptorModule.Load(executingAssembly);

            builder.RegisterModule(interceptorModule);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddCors();

            
            services.AddCoreModule();

           
            services.AddBusinessModule();

            // SHA256. 🎉
            services.AddSHA256();

            // AES. 🎉
            services.AddAES();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bilgi Sistemleri");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAPIExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
