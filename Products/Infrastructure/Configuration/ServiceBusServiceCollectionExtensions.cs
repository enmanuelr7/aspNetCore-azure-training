using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.eShop.Infrastructure.Configuration
{
    public static class ServiceBusServiceCollectionExtensions
    {
        public static IServiceCollection AddQueueClientFactory(this IServiceCollection services)
        {
            services.AddSingleton<IQueueClientFactory, QueueClientFactory>();

            return services;
        }

        public static IServiceCollection AddServiceBus(this IServiceCollection services)
        {
            services.AddSingleton<IServiceBus, ServiceBus>();

            return services;
        }
    }
}
