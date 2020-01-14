using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Application.Messages;
using Avanade.eShop.Application.Model;
using Avanade.eShop.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Avanade.eShop.Application.Commands
{
    public class CreateNewProductCommandHandler : IRequestHandler<CreateNewProductCommand, int>
    {
        private static readonly Random _rnd = new Random((int)DateTime.Now.Ticks);
        private readonly IProductRepository productRepository;

        public CreateNewProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<int> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {

            var productId = _rnd.Next(1, int.MaxValue);
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                ProductName = request.ProductName,
                ProductCode = request.ProductCode,
                Description = request.Description,
                Price = request.Price,
                ReleaseDate = request.ReleaseDate,
                StarRating = request.StarRating
            };

            try
            {
                await productRepository.CreateAsync(product);
            }
            catch (Exception)
            {

                throw;
            }

            return productId;
        }
    }
}
