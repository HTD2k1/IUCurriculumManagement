using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Keyless]
public partial class Curriculum8semestersTemplate
{
    public long Semester { get; set; }

    [Column("course_code")]
    [StringLength(255)]
    public string CourseCode { get; set; } = null!;

    [Column("Course Name")]
    [StringLength(255)]
    public string? CourseName { get; set; }

    [StringLength(39)]
    public string? Credit { get; set; }

    [StringLength(259)]
    public string? Program { get; set; }
}
