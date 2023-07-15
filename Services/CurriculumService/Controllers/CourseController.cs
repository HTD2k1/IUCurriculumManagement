using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using CurriculumService.Models;
using CurriculumService.Data;
using Microsoft.EntityFrameworkCore;
using RabbitMQService.Interfaces;

namespace CurriculumService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ILogger<Course> _logger;
        private readonly IuCurriculumContext _context;
        private readonly IRabbitMQService _service;

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

        [HttpPost(Name="CreateOrUpdateCourse")]
        public IActionResult Post([FromBody] Course course)
        {
            try
            {
                if (course == null) return new BadRequestObjectResult("NULL or INVALID COURSE");
                if (_context.Courses.Any(x => x.Id == course.Id))
                { 
                    _context.Courses.Update(course);
                }
                else  _context.Courses.Add(course);
                _context.SaveChanges();
                _context.Entry(course).State = EntityState.Detached;
                return new CreatedResult("/Course", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}