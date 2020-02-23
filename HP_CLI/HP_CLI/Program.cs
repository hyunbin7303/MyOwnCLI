using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace HP_CLI
{
    class Program
    {
        public IConfigurationRoot Configuration { get; }



        private static async Task<int> Main(string[] args)
        {
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "\\appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();


            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(config =>
                    {
                        config.ClearProviders();
                        config.AddProvider(new SerilogLoggerProvider(Log.Logger));
                    });
                    services.AddHttpClient();
                });
            try
            {
                return await builder.RunCommandLineApplicationAsync<iHPCmd>(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
    }
}
/*
 * The HttpClientFacoy is a new mechanism to create Httpclient instances
 * that are properly managed behind the scenes.
 * The httpClientFactory manages the lifetime of the handlers so that we have
 * a pool of them which can be reused.
 *
 * in net core 3.0
 * Checkout Worker Service template.
 * Adzuna API Service to extract data.
 *
 * 
 */