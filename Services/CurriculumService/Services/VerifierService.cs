using CurriculumService.Models;
using CurriculumService.Services.Interfaces;
using Microsoft.AspNetCore.Routing.Tree;
using RabbitMQService.Interfaces;
using CurriculumService.Helpers;

namespace CurriculumService.Services
{
    public class SemesterCurriculumVerifierService: IMessageProcessor
    {   
        private readonly IMessageProcessor _messageProcessor;   
        private readonly ILogger<SemesterCurriculumVerifierService> _logger;

        public async Task ProcessMessageAsync(string message)
        {
            _logger.LogInformation(message);
        }
        public SemesterCurriculumVerifierService(ILogger<SemesterCurriculumVerifierService> logger)
        {
            _logger = logger;
        }

        public void Verify()
        {
            throw new NotImplementedException();
        }
        public void DocumentHandler()
        {   
            //DocxHelper.ReadTablesFromWordDocument()
            throw new NotImplementedException();
        }
        public bool ValidateNewCurriculum()
        {
            return true;
        }
    }
}
    