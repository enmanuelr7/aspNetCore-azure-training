using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;

namespace Avanade.eShop.Infrastructure.Services
{
    public interface IQueueClientFactory
    {
        IQueueClient CreateClient(string name);
    }

    public class QueueClientFactory : IQueueClientFactory
    {
        private readonly ConcurrentDictionary<string, IQueueClient> _queueClientCache = new ConcurrentDictionary<string, IQueueClient>();
        private readonly IConfiguration _configuration;

        public QueueClientFactory(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IQueueClient CreateClient(string name)
        {
            if (!_queueClientCache.TryGetValue(name, out var queueClient))
            {
                queueClient = GetClient(name);
                _queueClientCache.TryAdd(name, queueClient);
            }

            return queueClient;
        }

        private IQueueClient GetClient(string queueName)
        {
            var serviceBus = _configuration["ConnectionStrings:ServiceBus"];
            return new QueueClient(serviceBus, queueName);
        }
    }
}
