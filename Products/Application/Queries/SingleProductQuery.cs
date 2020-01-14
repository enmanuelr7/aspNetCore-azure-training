using Avanade.eShop.Application.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.eShop.Application.Queries
{
    public class SingleProductQuery: IRequest<ProductDto>
    {
        public int ProductId { get; set; }
    }
}
