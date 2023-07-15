using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumService.DTOs
{
    public class CurriculumDto
    {
        public Models.Program? Program { get; set; } 
        public List<Course>? Courses { get; set; }
        public List<CourseCourseRelationship> CourseCourseRelationships { get; set; } = null!;
        public List<CourseProgram> CoursePrograms { get; set; } = null!;
    }
}
