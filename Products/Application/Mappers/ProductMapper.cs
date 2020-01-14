using Avanade.eShop.Application.Model;
using Avanade.eShop.Domain.Entities;

namespace Avanade.eShop.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                ImageUrl = product.ImageUrl,
                ProductId = product.ProductId,
                Description = product.Description,
                Price = product.Price,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ReleaseDate = product.ReleaseDate,
                StarRating = product.StarRating
            };
        }
    }
}
