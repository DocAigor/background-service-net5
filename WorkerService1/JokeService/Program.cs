using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)    
    .ConfigureServices(services =>
    {
        services.AddHostedService<WindowsBackgroundService>();
        services.AddHttpClient<JokeService>();
    })
    .UseWindowsService(options =>
    {
        options.ServiceName = ".NET Academy Yoox Joke Service";
    })
    .Build();

await host.RunAsync();