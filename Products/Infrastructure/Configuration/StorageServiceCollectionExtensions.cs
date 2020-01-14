using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Infrastructure.Services;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.eShop.Infrastructure.Configuration
{
    public static class StorageServiceCollectionExtensions
    {
        public static IServiceCollection AddImageStore(this IServiceCollection services)
        {
            return services;
        }

        private static BlobContainerClient GetContainerClient(IConfiguration configuration)
        {
            var storageConnectionString = configuration["ConnectionStrings:Storage"];
            var client = new BlobContainerClient(storageConnectionString, "uploads");
            
            return client;
        }
    }
}
