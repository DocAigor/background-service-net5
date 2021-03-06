using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ObesityCenterCaserta.Model;
using ObesityCenterCaserta.Reader;
using ObesityCenterCaserta.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObesityCenterCaserta
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IReader<Paziente> _reader;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, 
            IReader<Paziente> reader)
        {
            _logger = logger;
            _configuration = configuration;
            _reader = reader;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _reader.Read(_configuration["BMIPath"]);
                /*_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);*/
                await Task.Delay(30000, stoppingToken);
            }
        }

    }
}
