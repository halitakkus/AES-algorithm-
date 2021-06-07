using System;
using System.Collections.Generic;
using System.Text;
using Application.DataAccess.Abstract;
using Application.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DataAccess.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions contains extended IServiceCollection's methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register business module dependencies to IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccessModule(this IServiceCollection services)
        {
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<IIncomingVisitorDal, EfIncomingVisitorDal>();
            services.AddSingleton<IOperationClaimDal, EfOperationClaimDal>();

            return services;
        }
    }
}
