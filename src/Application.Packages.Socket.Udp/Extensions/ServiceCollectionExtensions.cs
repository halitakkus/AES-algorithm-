using Application.Packages.Socket.Core.Service;
using Application.Packages.Socket.Udp.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Packages.Socket.Udp.Extensions
{
    /// <summary>
    /// ServiceCollectionExtensions contains extended IServiceCollection's methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register Udp socket dependencies.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddUdpSocket(this IServiceCollection services)
        {
            services.AddSingleton<ISocketService, UdpSocketService>();

            return services;
        }
    }
}
