using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CurriculumProducer.DTOs
{
    public class CourseDTO
    {
        public long Semester { get; set; }
        [StringLength(255)]
        public string CourseCode { get; set; } = null!;

        [StringLength(255)]
        public string? CourseName { get; set; }
         
        [StringLength(39)]
        public string? Credit { get; set; }
    }
}
