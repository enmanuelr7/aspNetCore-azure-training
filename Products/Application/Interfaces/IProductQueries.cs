using Avanade.eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.eShop.Application.Interfaces
{
    public interface IProductQueries
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetAsync(int id);
    }
}
