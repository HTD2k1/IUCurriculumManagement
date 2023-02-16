using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Keyless]
public partial class CurriculumDsAe14year
{
    [Column("course_code")]
    [StringLength(255)]
    public string CourseCode { get; set; } = null!;

    [Column("Course Name")]
    [StringLength(255)]
    public string? CourseName { get; set; }

    [StringLength(255)]
    public string? Program { get; set; }

    [Column("year")]
    public int Year { get; set; }

    [Column("semester")]
    public int Semester { get; set; }
}
