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

namespace CurriculumService.Services
{
    public class SemesterCurriculumVerifierService: IMessageProcessor
    {      
        private readonly ILogger<SemesterCurriculumVerifierService> _logger;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IuCurriculumContext _curriculumContext;  
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
                            _logger.LogInformation("Successfully validate ");
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
            int? sum = 0;
            foreach(var course in courses)
            {
                sum += course.CreditTheory + course.CreditTheory;
            }
            _logger.LogInformation($"Total credit score: {sum}");
            return (sum < 146) ? true : false;
        }
    }
}
    