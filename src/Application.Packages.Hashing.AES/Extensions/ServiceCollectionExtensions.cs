using Application.Packages.Encryption.AES.Service;
using Application.Packages.Encryption.Core.Service;
using Application.Packages.Hashing.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Packages.Hashing.AES.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Aes algoritmasının servislerde kullanılabilmesi için.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAES(this IServiceCollection services)
        {
            services.AddSingleton<IEncryptionService, AESService>();

            return services;
        }
    }
}
