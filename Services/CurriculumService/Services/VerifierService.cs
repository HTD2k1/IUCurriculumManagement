using CurriculumService.Models;
using CurriculumService.Services.Interfaces;
using Microsoft.AspNetCore.Routing.Tree;
using RabbitMQService.Interfaces;
using Newtonsoft.Json;
using BlobStorageService;

namespace CurriculumService.Services
{
    public class SemesterCurriculumVerifierService: IMessageProcessor
    {      
        private readonly ILogger<SemesterCurriculumVerifierService> _logger;
        private readonly IBlobStorageService _blobStorageService;

        public SemesterCurriculumVerifierService(ILogger<SemesterCurriculumVerifierService> logger, IBlobStorageService blobStorageService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _blobStorageService = blobStorageService ?? throw new ArgumentNullException(nameof(blobStorageService));
        }
    
        public async Task ProcessMessageAsync(string message)
        {
            var curriculumEvent = JsonConvert.DeserializeObject<CurriculumEvent>(message);
            await _blobStorageService.DownloadFilesAsync(curriculumEvent.Payload);
        }
        public void Verify()
        {
            throw new NotImplementedException();
        }
        public void DocumentHandler()
        {   
            throw new NotImplementedException();
        }

        public void CSVHandler()
        {
            throw new NotImplementedException();
        }
        public bool ValidateNewCurriculum()
        {
            return true;
        }
    }
}
    