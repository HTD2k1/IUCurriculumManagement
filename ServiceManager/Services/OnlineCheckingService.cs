using RabbitMQService.Interfaces;
using Common.MicroserviceModels;
namespace ServiceManager.Services
{
    public class OnlineCheckingService: IMessageProcessor
    {
        private readonly ILogger<BackgroundService> _logger;
        private readonly ServiceContext _serviceContext;

        public OnlineCheckingService(ILogger<BackgroundService> logger, ServiceContext serviceContext)
        {
            _logger = logger;
            _serviceContext= serviceContext;
        }
        public async Task ProcessMessageAsync(string message)
        {   
            _logger.LogInformation("Process message: "+message);
            var serviceEvent = JsonConvert.DeserializeObject<MicroService>(message) ?? throw  new Exception("Message cannot be serialized");
            var availableMicroService = _serviceContext.MicroServices.FirstOrDefault(x => x.Id == serviceEvent.Id);
            if(availableMicroService== null) {
                _serviceContext.MicroServices.Add(serviceEvent);
            }
            else {
                availableMicroService.StatusLog.Add(serviceEvent.CurrentStatus);
                _serviceContext.SaveChanges();
            }
        } 
    }
}
