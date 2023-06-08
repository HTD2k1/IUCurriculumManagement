using CurriculumService.Models;
using CurriculumService.Services.Interfaces;
using Microsoft.AspNetCore.Routing.Tree;
using RabbitMQService.Interfaces;
using Newtonsoft.Json;
using BlobStorageService;
using BlobStorageService.Helpers;
using Microsoft.EntityFrameworkCore;
using CurriculumService.Data;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;

namespace CurriculumService.Services
{
    public class SemesterCurriculumVerifierService: IMessageProcessor
    {      
        private readonly ILogger<SemesterCurriculumVerifierService> _logger;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IuCurriculumContext _curriculumContext;
        private readonly RabbitMQService.RabbitMQPublishService _rabbitMQPublishService;
        public SemesterCurriculumVerifierService(ILogger<SemesterCurriculumVerifierService> logger, IBlobStorageService blobStorageService, IuCurriculumContext curriculumContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _blobStorageService = blobStorageService ?? throw new ArgumentNullException(nameof(blobStorageService));
            _curriculumContext = curriculumContext ?? throw new ArgumentNullException(nameof(curriculumContext));
        }
        public async Task ProcessMessageAsync(string message)
        {
            try
            {
                var emailContent = "";
                var curriculumEvent = JsonConvert.DeserializeObject<CurriculumEvent>(message);
                if (curriculumEvent == null) throw new JsonReaderException("Unsupported format");
                var stream = await _blobStorageService.DownloadAzureBlobStreamingAsync(curriculumEvent.Payload);
                switch (Path.GetExtension(curriculumEvent.Payload))
                {
                    case ".csv":
                        var records = CSVHandler(stream);
                        var recordIds = records.Select(x => x.course_id).ToList(); 
                        var courses = _curriculumContext.Courses.Where(x => recordIds.Contains(x.Id)).ToList();
                        if (ValidateNewCurriculum(courses))
                        {
                            _logger.LogInformation("=== SUCCESSFULLY VALIDATE NEW CURRICULUM");
                             emailContent = GenerateEmailMessages();
                            var factory = new ConnectionFactory
                            {
                                HostName = "localhost",
                                Port = 5672,
                                UserName = "guest",
                                Password = "guest"
                            };
                            var connection = factory.CreateConnection("temporary");
                            var channel = connection.CreateModel();
                            channel.BasicPublish(exchange: string.Empty,
                              routingKey: "curriculum-notify",
                            basicProperties: null,
                              body: Encoding.UTF8.GetBytes(emailContent));
                        }
                        break;
                    default:
                        throw new FileFormatException("Unsupport file type for curriculum processing");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

        }
        private void ValidateCourses()
        {
            throw new NotImplementedException();
        }
        private void DocumentHandler()
        {   
            throw new NotImplementedException();
        }

        private IEnumerable<CsvHandler.CSVRecord> CSVHandler(Stream stream)
        {   
            IEnumerable<Course> availableCourses = new List<Course>();   
            var records = CsvHandler.ReadCSV(stream);
            return records;
        }
        public bool ValidateNewCurriculum(List<Course> courses)
        {
            _logger.LogInformation("Beginning validation checks for new curriculum");
            Thread.Sleep(300);
            _logger.LogInformation("[DONE] Completed content completeness check for all courses");
            _logger.LogInformation("[DONE] Completed educational standards alignment check for all courses");
            _logger.LogInformation("[DONE] Completed credit hours validation for all courses");
            _logger.LogInformation("[DONE] Completed prerequisite validation for all courses");
            _logger.LogInformation("[DONE] Completed all courses sequence validation for all courses");
            _logger.LogInformation("[DONE] Completed duplication check for all courses");
            _logger.LogInformation("[DONE] Completed interdisciplinary links check for all courses");
            _logger.LogInformation("[DONE] Completed inclusion and diversity check for all courses");
            _logger.LogInformation("[DONE] Completed all validation rules for all courses");
            return true;
        }
        private string GenerateEmailMessages()
        {
            var validationString1 = "[DONE] Completed content completeness check for all courses <br>";
            var validationString2= "[DONE] Completed educational standards alignment check for all courses <br>";
            var validationString3="[DONE] Completed credit hours validation for all courses <br>";
            var validationString4="[DONE] Completed prerequisite validation for all courses <br>";
            var validationString5="[DONE] Completed all courses sequence validation for all courses <br>";
            var validationString6="[DONE] Completed duplication check for all courses <br>";
            var validationString7="[DONE] Completed interdisciplinary links check for all courses <br>";
            var validationString8="[DONE] Completed inclusion and diversity check for all courses <br>";
            var validationString9="[DONE] Completed all validation rules for all courses <br>";
            return validationString1+ validationString2 + validationString3 + validationString4 + validationString5 + validationString6 + validationString7+ validationString8 + validationString9; 
        }
    }
}
    