using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService
{
    public class RabbitMQListenerService : BackgroundService
    {
        private readonly IRabbitMQService _rabbitMQService;
        private readonly ILogger<RabbitMQListenerService> _logger;

        public RabbitMQListenerService(IRabbitMQService service, ILogger<RabbitMQListenerService> logger)
        {
            _rabbitMQService = service;
            _logger = logger;
            _logger.LogInformation("RabbitMQListenerService Injected Logger");
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background service is running at: {time}", DateTimeOffset.Now);
            cancellationToken.ThrowIfCancellationRequested();
            await _rabbitMQService.RegisterConsumer();
        }
    }
}
