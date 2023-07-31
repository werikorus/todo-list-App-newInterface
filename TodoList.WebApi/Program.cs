//using Azure.Extensions.AspNetCore.Configuration.Secrets;
//using Azure.Identity;
//using Azure.Security.KeyVault.Secrets;

namespace TodoList.WebApi;

public static class Program
{
    public static void Main(params string[] args) => CreateWebHostBuilder(args).Build().Run();

    private static IHostBuilder CreateWebHostBuilder(params string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                var buildConfiguration = config.Build();

                //string kvURL = buildConfiguration["KeyVaultConfig:KVUrl"];
                //string tenantId = buildConfiguration["KeyVaultConfig:TenantId"];
                //string clientId = buildConfiguration["KeyVaultConfig:ClientId"];
                //string clientSecretId = buildConfiguration["KeyVaultConfig:ClientSecretId"];

                //var credential = new ClientSecretCredential(tenantId, clientId, clientSecretId);

//                var client = new SecretClient(new Uri(kvURL), credential);
  //              config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}