using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using CurriculumService.Models;
using CurriculumService.Data;
namespace CurriculumService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ILogger<Course> _logger;
        private readonly IuCurriculumContext _context;

        public CourseController(ILogger<Course> logger, IuCurriculumContext dBContext)
        {
            _logger = logger;
            _context = dBContext;
        }

        [HttpGet(Name = "GetCourse")]
        public IEnumerable<Course> Get()
        {
            return _context.Courses.Select(x => x).Take(5).ToList();
        }
    }
}