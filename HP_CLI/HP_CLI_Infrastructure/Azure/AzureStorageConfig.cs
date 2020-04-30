using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace HP_CLI_Infrastructure.Azure
{

    public class AzureStorageConfig
    {
        public string ModelStorageKeyVaultKey { get; set; }
        public string TrainingStorageKeyVaultKey { get; set; }
        public string AccountName { get; set; }
        public string ImageContainer { get; set; }
        public string AccountKey { get; set; }

        public AzureStorageConfig()
        {
            AccountName = "";
        }
        public static string ConnectionString()
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //configuration.GetConnectionString("ConnectionStrings");

            //var Configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .Build();
            return "DefaultEndpointsProtocol=https;AccountName=kevinazurestorage;AccountKey=L20Da4XlWc9PBBuuNEW6yrCYg74JzBrFl5h6FTp8thXktrGgMTF/CVmilHNLMmEYTMq9ONxVSCOioSdc5E7xEw==;EndpointSuffix=core.windows.net";
        }

        public override string ToString() =>
            $"Account name : {AccountName}, Account Key : {AccountKey}, ImageContainer : {ImageContainer}, ModelStorageKeyVaultKey : {ModelStorageKeyVaultKey}";

    }
}
