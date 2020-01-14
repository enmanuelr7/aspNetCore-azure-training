using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.eShop.Application.Model
{
    public class ProductListViewModel
    {
        public ProductListViewModel(IEnumerable<ProductDto> products)
        {
            Products = new List<ProductDto>(products);
        }

        public ProductListViewModel()
        {
            Products = new List<ProductDto>();
        }

        public IList<ProductDto> Products { get; private set; }
    }
}
