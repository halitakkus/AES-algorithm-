using System;
using System.Collections.Generic;
using System.Text;
using Application.Business.Abstract;
using Application.Business.Concrete;
using Application.Business.ValidationRules.FluentValidation;
using Application.Core.Entities.Concrete;
using Application.DataAccess.Extensions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Business.Extensions
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
        public static IServiceCollection AddBusinessModule(this IServiceCollection services)
        {
            services.AddSingleton<IUserManager, UserManager>();
            services.AddSingleton<IIncomingVisitorManager, IncomingVisitorManager>();
            services.AddSingleton<IOperationClaimManager, OperationClaimManager>();

            services.AddSingleton<IValidator<User>, UserValidator>();

            // Register data access module. 🎉

            services.AddDataAccessModule();

            return services;
        }
    }
}
