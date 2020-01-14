using Avanade.eShop.Application.Interfaces;
using Avanade.eShop.Application.Messages;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.eShop.Infrastructure.Services
{
    public class ServiceBus : IServiceBus
    {
        private readonly IQueueClientFactory _queueClientFactory;
        private readonly ISystemTime _systemTime;

        public ServiceBus(IQueueClientFactory queueClientFactory, ISystemTime systemTime)
        {
            this._queueClientFactory = queueClientFactory;
            this._systemTime = systemTime;
        }

        public async Task SendAsync(IntegrationMessage message)
        {
            if (message == null) throw new ArgumentNullException();

            var messageType = message.GetType();
            var queueName = GetQueueName(messageType);
            var queueClient = GetQueueClient(queueName);

            // Apply sensibe defaults
            if (message.Version == default)
            {
                message.Version = 1;
            }

            if (message.Type == default)
            {
                message.Type = messageType.Name;
            }

            if (message.Timestamp == default)
            {
                message.Timestamp = _systemTime.UtcNow;
            }

            var jsonMessage = JsonConvert.SerializeObject(message);
            var bytes = Encoding.UTF8.GetBytes(jsonMessage);

            // Push a message onto a queue
            await queueClient.SendAsync(new Message(bytes)
            {
                ContentType = "application/json"
            });
        }

        private string GetQueueName(Type messageType)
        {
            var queueName = messageType.Name;
            var queueAttributes = messageType.GetCustomAttributes(typeof(QueueAttribute), false);
            if (queueAttributes.Length == 1)
            {
                var queueAttribute = (QueueAttribute)queueAttributes[0];
                if (!string.IsNullOrWhiteSpace(queueAttribute.Name))
                {
                    return queueAttribute.Name;
                }
            }

            return queueName;
        }

        private IQueueClient GetQueueClient(string queueName)
        {
            return _queueClientFactory.CreateClient(queueName);
        }
    }
}
