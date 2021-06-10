using System;
using System.Collections.Generic;
using System.Text;
using Application.Packages.Hashing.AES.Service;
using Application.Packages.Hashing.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Packages.Hashing.AES.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions contains extended IServiceCollection's methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register AES hash dependencies.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAES(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, AESHashService>();

            return services;
        }
    }
}
