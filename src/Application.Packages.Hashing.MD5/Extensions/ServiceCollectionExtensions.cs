﻿using System;
using System.Collections.Generic;
using System.Text;
using Application.Packages.Hashing.Core.Service;
using Application.Packages.Hashing.MD5.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Packages.Hashing.MD5.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions contains extended IServiceCollection's methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Md5 hash servisinin servislere eklenmesi.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMD5(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, MD5HashService>();

            return services;
        }
    }
}
