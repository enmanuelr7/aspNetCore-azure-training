using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avanade.eShop.Infrastructure.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Avanade.eShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) => {

                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile($"appsettings.json", optional: false);
                    builder.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true);
                    builder.AddEnvironmentVariables();

                    var configuration = builder.Build();
                    var keyVault = configuration["ConnectionStrings:KeyVault"];
                    var azureServiceTokenProvider = new AzureServiceTokenProvider();
                    var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(
                                                azureServiceTokenProvider.KeyVaultTokenCallback));

                    builder.AddAzureKeyVault(keyVault, kv, new KeyValueSecretManager());

                }).ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    
}
