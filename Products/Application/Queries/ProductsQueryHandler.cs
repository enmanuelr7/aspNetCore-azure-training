using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Application.Mappers;
using Avanade.eShop.Application.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.eShop.Application.Queries
{
    public class ProductsQueryHandler : IRequestHandler<ProductsQuery, ProductListViewModel>
    {
        private readonly IProductQueries productQueries;
        private readonly ILogger logger;

        public ProductsQueryHandler(IProductQueries productQueries, ILogger<ProductsQueryHandler> logger)
        {
            this.productQueries = productQueries;
            this.logger = logger;
        }
        public async Task<ProductListViewModel> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {

            logger.LogInformation($"About to retrieve all products");
            var products = await productQueries.GetAllAsync();
            var productDtos = products.Select(p => p.ToProductDto());
            logger.LogInformation($"Products retrieved successfully");
            return new ProductListViewModel(productDtos);
        }
    }
}
