using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.eShop.Application.Model
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public float StarRating { get; set; }

        public string ImageUrl { get; set; }
    }
}
