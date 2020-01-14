using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Application.Mappers;
using Avanade.eShop.Application.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.eShop.Application.Queries
{
    public class SingleProductQueryHandler:IRequestHandler<SingleProductQuery,ProductDto>
    {
        private readonly IProductQueries productQueries;

        public SingleProductQueryHandler(IProductQueries productQueries)
        {
            this.productQueries = productQueries;
        }

        public async Task<ProductDto> Handle(SingleProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await productQueries.GetAsync(request.ProductId);
                return product?.ToProductDto();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
