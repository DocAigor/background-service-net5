using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace FinancialServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IDataRetriever, DataDogRetriever>();
                    services.AddSingleton<IDogApiMapper, DogApiJsonMapper>();
                    services.AddSingleton<IDataDogSearcher, DataDogSearcher>();
                    services.AddSingleton<IWriter, DogWriter>();
                    services.AddSingleton<HttpClient>();
                    services.AddSingleton<DogSitter>();
                    services.AddHostedService<Worker>();
                });
    }
}
