using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Infrastructure.Configuration;
using Avanade.eShop.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Add system time service
            services.AddSingleton<ISystemTime, SystemTime>();

            // Add product repository
            services.AddProductRepository();

            // Add product queries
            services.AddProductQueries();

            // Add cosmos client
            services.AddCosmosclient();

            return services;
        }
    }
}
