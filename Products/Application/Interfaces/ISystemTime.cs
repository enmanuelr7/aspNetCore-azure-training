using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.eShop.Application.Interfaces
{
    public interface ISystemTime
    {
        DateTimeOffset UtcNow { get; }
    }
}
