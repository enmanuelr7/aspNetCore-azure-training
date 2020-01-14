using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Domain.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.eShop.Infrastructure.Repositories.CosmosDB
{
    public class ProductRepository : IProductRepository, IProductQueries
    {
        private Container container;

        public ProductRepository(CosmosClient cosmosClient)
        {
            container = cosmosClient.GetContainer("ArgentinaData","Documents");
        }


        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = new List<Product>();
            var iter = container.GetItemQueryIterator<Product>(
                new QueryDefinition("select * from c"));
            while (iter.HasMoreResults)
            {
                var res = await iter.ReadNextAsync();

                foreach(var product in res)
                {
                    products.Add(product);
                }
            }

            return products;

        }

        public async Task<Product> GetAsync(int id)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.productId = @productId").WithParameter("@productId", id);
            var iter = container.GetItemQueryIterator<Product>(query);
            if (iter.HasMoreResults)
            {
                var results = await iter.ReadNextAsync();
                return results.FirstOrDefault();
            }
            return null;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            try
            {
                return await container.CreateItemAsync(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
