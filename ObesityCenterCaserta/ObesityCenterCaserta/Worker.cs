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
        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Installer();
                /*_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);*/
                await Task.Delay(30000, stoppingToken);
            }
        }

        private void Installer()
        {
            var csvreader = new CSVReader();
            var pazienti = csvreader.Read(_configuration["BMIPath"]);
            var tabellaBMI = new List<ClassificationBMI>
            {
                new ClassificationBMI
                {
                    Classification = "Sottopeso",
                    MinIndex = _configuration.GetValue<decimal>("Sottopeso:Min"),
                    MaxIndex = _configuration.GetValue<decimal>("Sottopeso:Max")
                },
                new ClassificationBMI
                {
                    Classification = "Normopeso",
                    MinIndex = _configuration.GetValue<decimal>("NormoPeso:Min"),
                    MaxIndex = _configuration.GetValue<decimal>("NormoPeso:Max")
                },
                new ClassificationBMI
                {
                    Classification = "Sovrappeso",
                    MinIndex = _configuration.GetValue<decimal>("Sovrappeso:Min"),
                    MaxIndex = _configuration.GetValue<decimal>("Sovrappeso:Max")
                },
                new ClassificationBMI
                {
                    Classification = "Obeso",
                    MinIndex = _configuration.GetValue<decimal>("Obeso:Min"),
                    MaxIndex = _configuration.GetValue<decimal>("Obeso:Max")
                }
            };
            var giudizionoz = new Nowzaradan(tabellaBMI);
            var csvwriter = new CSVWriter(giudizionoz);
            csvwriter.WriteData(_configuration["ResultPath"], pazienti);
        }
    }
}
