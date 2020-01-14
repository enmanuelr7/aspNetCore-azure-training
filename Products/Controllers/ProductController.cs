using Avanade.eShop.Application.Commands;
using Avanade.eShop.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Avanade.eShop.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var productListViewModel = await mediator.Send(new ProductsQuery());
            return Ok(productListViewModel.Products);
        }

        [HttpGet("{id}", Name = nameof(GetProductByIdAsync))]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var product = await mediator.Send(new SingleProductQuery { ProductId = id });
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateaproductAsync([FromBody] CreateNewProductCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            int id = await mediator.Send(command);
            return AcceptedAtRoute(nameof(GetProductByIdAsync), new { id });

        }
    }
}
