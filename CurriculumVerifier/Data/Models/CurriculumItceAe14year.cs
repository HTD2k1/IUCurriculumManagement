using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CurriculumItceAe14year
{
    public string CourseCode { get; set; } = null!;

    public string? CourseName { get; set; }

    public string? Program { get; set; }

    public int Year { get; set; }

    public int Semester { get; set; }
}
