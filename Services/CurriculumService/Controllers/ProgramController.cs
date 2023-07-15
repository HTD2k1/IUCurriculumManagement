using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using CurriculumService.Models;
using Microsoft.EntityFrameworkCore;
using CurriculumService.Data;
using Microsoft.EntityFrameworkCore.Query;
using RabbitMQService.Interfaces;

namespace CurriculumService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly ILogger<ProgramController> _logger;
        private readonly IuCurriculumContext _context;
        
        public ProgramController(ILogger<ProgramController> logger, IuCurriculumContext dBContext)
        {
            _logger = logger;
            _context = dBContext;
        }
        [HttpGet(Name = "GetAllPrograms")]
        public IEnumerable<Models.Program> GetAllPrograms()
        {
            var result =  _context.Programs.Select(x => x).ToList();
            return result;
        }
        [HttpGet("RelationShip")]
        public IActionResult GetProgramCourseRelationship()
        {
            try
            {
                var result = _context.CoursePrograms.Select(x => x).ToList();
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{programName}")]
        public IActionResult GetProgramByName(string programName)
        {
            try
            {
                var program = _context.Programs
                    .FirstOrDefault(p => p.Name == programName);
                return new OkObjectResult(program);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPost("")]
        public IActionResult PostNewCurriculum([FromBody] Models.Program? newProgram)
        {
            try
            {
                if (newProgram == null)
                {
                    _logger.LogError("Null Program object sent from client");
                    return new BadRequestObjectResult("Null body sent");
                }
                if (!ModelState.IsValid)
                {   
                    _logger.LogError("Invalid Program object sent from client.");
                    return new BadRequestObjectResult("Invalid format");
                }
                var programTypeAbbreviation = _context.ProgramTypes.Where(x => x.Id == newProgram.ProgramTypeId)
                    .Select(x => x.Type).FirstOrDefault() ?? throw new NullReferenceException("Unknown program type");

                _context.Programs.Add(newProgram);
                _context.SaveChanges();
                var location = new Uri("/Program");
                return new CreatedResult(location,null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}