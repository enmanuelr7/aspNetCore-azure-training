using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Application.Queries;
using Avanade.eShop.Infrastructure.Repositories.CosmosDB;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.eShop.Infrastructure.Configuration
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddProductRepository(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
            return services;
        }

        public static IServiceCollection AddProductQueries(this IServiceCollection services)
        {
            services.AddSingleton<IProductQueries, ProductRepository>();
            return services;
        }

        //public static IServiceCollection AddCosmosclient(this IServiceCollection services)
        //{
        //    services.AddSingleton(provider => new CosmosClient("AccountEndpoint=https://argentina-cosmosdb.documents.azure.com:443/;AccountKey=hGFzAgcdSFqhjxY0SVSZlOqBmCvnXsQbdR8LunMYylFSQ6d9qO2mNFGY0iWghpGHk9lAEO8S0vTmDz9N5YQUEA==;"));
        //    return services;
        //}

        public static IServiceCollection AddCosmosclient(this IServiceCollection services)
        {
            services.AddSingleton(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();
                var client = GetDocumentClient(configuration);

                return client;
            });

            return services;
        }


        private static CosmosClient GetDocumentClient(IConfiguration configuration)
        {
            var cosmosKey = configuration["Keys:CosmosDb"];
            var cosmosUrl = configuration["ConnectionStrings:CosmosDB"];
            var client = new CosmosClient(cosmosUrl, cosmosKey);

            return client;
        }
    }
}
