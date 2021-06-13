using System;
using System.Collections.Generic;
using System.Text;
using Application.Packages.Hashing.Core.Service;
using Application.Packages.Hashing.SHA256.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Packages.Hashing.SHA256.Extensions
{
   
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register SHA256 hash servisinin bağımlılıklara eklenmesi.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSHA256(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, SHA256HashService>();

            return services;
        }
    }
}
