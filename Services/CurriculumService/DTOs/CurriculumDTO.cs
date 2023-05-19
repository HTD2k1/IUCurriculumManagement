using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumService.DTOs
{
    public class CurriculumDTO
    {
        public string Program { get; set; }
        public List<CourseDTO> courses { get; set; } = new List<CourseDTO>();   
        public string? EnglishRequirement { get; set; }
    }
}
