using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using CurriculumService.Models;
using CurriculumService.Data;
using CurriculumService.DTOs;
using Microsoft.EntityFrameworkCore;
using RabbitMQService.Interfaces;

namespace CurriculumService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurriculumController : ControllerBase
    {
        private readonly ILogger<Course> _logger;
        private readonly IuCurriculumContext _context;
        private readonly IRabbitMQService _service;

        public CurriculumController(ILogger<Course> logger, IuCurriculumContext dBContext)
        {
            _logger = logger;
            _context = dBContext;
        }

        [HttpGet("{programName}")]
        public IActionResult GetCurriculumByProgramName( string programName)
        {
            var program = _context.Programs.Where(p => p.Name == programName).FirstOrDefault();
            if (program == null)
                return new NotFoundResult();
            var coursePrograms = _context.CoursePrograms
                .Where(cp => cp.ProgramId == program.Id)
                .ToList();
            var courseIds = coursePrograms.Select(x => x.CourseId).ToList();
            var courses = _context.Courses.Where(x => courseIds.Contains(x.Id)).ToList();
            var courseCourseRelationShips = _context.CourseCourseRelationships
                .Select(x => x)
                .Where(x => courseIds.Contains(x.CourseId1)).ToList();

            var coursePathways = _context.CoursePathways
                .Where(x => x.PathwayId == 3 && courseIds.Contains(x.CourseId) && x.ProgramId == program.Id).ToList();
            return new OkObjectResult(new CurriculumDto()
            {
                Program = program,
                CoursePrograms = coursePrograms,
                CourseCourseRelationships = courseCourseRelationShips,
                Courses = courses,
                CoursePathways = coursePathways
            });
        }
        [HttpPost("Update")]
        public IActionResult UpdateCurriculum([FromBody] CurriculumDto curriculumDto)
        {
            try
            {
                if (curriculumDto.Courses != null && curriculumDto.CoursePrograms != null &&
                    curriculumDto.Program != null && curriculumDto.CourseCourseRelationships != null
                    && curriculumDto.CoursePathways != null)
                {
                    if (_context.Programs.Any(x => x.Id == curriculumDto.Program.Id))
                    {
                        _context.Programs.Update(curriculumDto.Program);
                    }
                    else
                    {
                        _context.Programs.Add(curriculumDto.Program);
                    }
                    foreach (var course in curriculumDto.Courses)
                    {
                        if (_context.Courses.Any(x => x.Id == course.Id))
                        {
                            _context.Courses.Update(course);
                        }
                        else
                        {
                            _context.Courses.Add(course);
                        }
                    }
                    foreach (var courseProgram in curriculumDto.CoursePrograms)
                    {
                        if (_context.CoursePrograms.Any(x => x.CourseId == courseProgram.CourseId && x.ProgramId == courseProgram.ProgramId))
                        {
                            _context.CoursePrograms.Update(courseProgram);
                        }
                        else
                        {
                            _context.CoursePrograms.Add(courseProgram);
                        }
                    }
                    foreach (var relationship in curriculumDto.CourseCourseRelationships)
                    {
                        if (_context.CourseCourseRelationships.Any(x => x.CourseId1 == relationship.CourseId1 && x.CourseId2 == relationship.CourseId2))
                        {
                            _context.CourseCourseRelationships.Update(relationship);
                        }
                        else
                        {
                            _context.CourseCourseRelationships.Add(relationship);
                        }
                    }
                    foreach (var coursePathway in curriculumDto.CoursePathways)
                    {
                        if (_context.CoursePathways.Any(x => x.CourseId == coursePathway.CourseId && x.ProgramId == coursePathway.ProgramId && coursePathway.PathwayId == 3))
                        {
                            _context.CoursePathways.Update(coursePathway);
                        }
                        else
                        {
                            _context.CoursePathways.Add(coursePathway);
                        }
                    }
                }

                _context.SaveChanges();
                return new OkResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
          

        }
    }
}