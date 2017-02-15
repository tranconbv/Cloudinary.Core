using CloudinaryDotNet;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class CloudinaryDependencyInjectionHelper
    {
        /// <summary>
        /// Add cloudinary service, Environment Variable CLOUDINARY_URL will be used for authentication
        /// </summary>
        /// <param name="services">the Ioc builder</param>
        /// <param name="lifetime">lifetime of service, Transient=Lower memory, Singleton=More performance </param>
        public static IServiceCollection AddCloudinary(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.Add(new ServiceDescriptor(typeof(Cloudinary),c=>new Cloudinary(), lifetime ));
            return services;
        }

        /// <summary>
        /// Add cloudinary service, Account will be used
        /// </summary>
        /// <param name="services">the Ioc builder</param>
        /// <param name="account">Cloudinary account details</param>
        /// <param name="lifetime">lifetime of service, Transient=Lower memory, Singleton=More performance </param>
        public static IServiceCollection AddCloudinary(this IServiceCollection services, Account account, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            services.Add(new ServiceDescriptor(typeof(Cloudinary),c=>new Cloudinary(account), lifetime ));
            return services;
        }

    }
}