using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Curriculum4yearsTemplate
{
    public int Year { get; set; }

    public int Semester { get; set; }

    public string CourseCode { get; set; } = null!;

    public string? CourseName { get; set; }

    public string? Credit { get; set; }

    public string? Program { get; set; }
}
