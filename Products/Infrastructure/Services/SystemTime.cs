using Avanade.eShop.Application.Interfaces;
using System;

namespace Avanade.eShop.Infrastructure.Services
{
    public class SystemTime : ISystemTime
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
