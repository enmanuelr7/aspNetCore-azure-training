using Avanade.eShop.Application.Messages;
using System.Threading.Tasks;

namespace Avanade.eShop.Application.Interfaces
{
    public interface IServiceBus
    {
        Task SendAsync(IntegrationMessage message);
    }
}
