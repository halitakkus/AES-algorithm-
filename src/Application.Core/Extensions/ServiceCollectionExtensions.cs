using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Core.Configuration.Context;
using Application.Core.Configuration.Environment;

namespace Application.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register core module dependencies to IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddCoreModule(this IServiceCollection services)
        {
            services.AddSingleton<IEnvironmentService, EnvironmentService>();
            services.AddSingleton<IApplicationConfigurationContext, ApplicationConfigurationContext>();
        }
    }
}
