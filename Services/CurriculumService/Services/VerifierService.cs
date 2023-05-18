using CurriculumService.Models;
using CurriculumService.Services.Interfaces;
using Microsoft.AspNetCore.Routing.Tree;
using RabbitMQService.Interfaces;

namespace CurriculumService.Services
{
    public class SemesterCurriculumVerifierService: IMessageProcessor
    {   
        private readonly IMessageProcessor _messageProcessor;   
        private readonly ILogger<SemesterCurriculumVerifierService> _logger;

        public SemesterCurriculumVerifierService(ILogger<SemesterCurriculumVerifierService> logger)
        {
            _logger = logger;
        }

        public void Verify()
        {
            throw new NotImplementedException();
        }

        public async Task ProcessMessageAsync(string message) { 
           _logger.LogInformation(message);
        }
        public bool ValidateNewCurriculum()
        {
            return true;
        }
    }
}
    