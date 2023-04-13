using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RabbitMQService> _logger;

        public RabbitMQListenerService(IRabbitMQService service, ILogger<RabbitMQService> logger)
        {
            _rabbitMQService = service;
            _logger = logger;
            _logger.LogInformation("RabbitMQListenerService Injected Logger");
        }
        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _rabbitMQService.RegisterConsumer();
           
            return Task.CompletedTask;
        }
    }
}
