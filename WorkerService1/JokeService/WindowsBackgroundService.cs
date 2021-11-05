using JokeService.Common;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

public sealed partial class WindowsBackgroundService : BackgroundService
{
    private readonly JokeClient _jokeService;
    private readonly ILogger<WindowsBackgroundService> _logger;

    public WindowsBackgroundService(JokeClient jokeService, 
        ILogger<WindowsBackgroundService> logger)
        => (_jokeService, _logger) = (jokeService, logger);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            string joke = await _jokeService.GetJokeAsync();
            _logger.LogWarning(joke);
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}