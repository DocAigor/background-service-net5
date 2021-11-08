using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialServices
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly DogSitter dogSitter;

        public Worker(ILogger<Worker> logger, IConfiguration configuration,DogSitter dogSitter)
        {
            _logger = logger;
            _configuration = configuration;
            this.dogSitter = dogSitter;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                dogSitter.EsciIlCane(_configuration["datadogurl"],
                    _configuration["cani"]);
                await Task.Delay(30000, stoppingToken);
            }
        }
    }
}
