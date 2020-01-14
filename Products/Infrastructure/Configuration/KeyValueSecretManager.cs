using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace Avanade.eShop.Infrastructure.Configuration
{
    public class KeyValueSecretManager : IKeyVaultSecretManager
    {
        public string GetKey(SecretBundle secret)
        {
            var val = secret.SecretIdentifier.Name.Replace("-", ":");
            return val;
        }

        public bool Load(SecretItem secret)
        {
            return true;
        }
    }
}
