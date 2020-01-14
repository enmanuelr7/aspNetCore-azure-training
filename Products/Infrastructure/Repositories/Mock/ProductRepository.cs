using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.eShop.Infrastructure.Repositories.Mock
{
    public class ProductRepository : IProductQueries
    {
        public List<Product> products = new List<Product> {

                new Product {
                    ProductName = "Hp Laptop",
                    StarRating= 3.5f,
                    ProductId = 1,
                    Description = "Brand New HP Laptop",
                    Price = 200 ,
                    ProductCode ="PS434FD",
                    ReleaseDate = new DateTimeOffset(new DateTime(2000,6,6)),
                    ImageUrl="assets/images/hpLaptop.jpg"
                },
                new Product {
                    ProductName = "Dell Laptop",
                    StarRating= 4.5f,
                    ProductId = 2,
                    Description = "Brand New Dell Laptop",
                    Price = 250 ,
                    ProductCode ="PS4OKPL",
                    ReleaseDate = new DateTimeOffset(new DateTime(2015,8,6)),
                    ImageUrl="assets/images/dellLaptop.jpg"
                }
        };

    

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            var allProducts = await GetAllAsync();
            return allProducts.FirstOrDefault(product => product.ProductId == id);
        }
    }
}
