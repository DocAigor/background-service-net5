using JokeService.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)    
    .ConfigureServices(services =>
    {
        services.AddHostedService<WindowsBackgroundService>();
        services.AddSingleton<JokeClient>();
    })
    .UseWindowsService(options =>
    {
        options.ServiceName = ".NET Academy Yoox Joke Service";
    })
    .Build();

await host.RunAsync();