using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CurriculumCsAe14year
{
    public string CourseCode { get; set; } = null!;

    public string? CourseName { get; set; }

    public int Year { get; set; }

    public int Semester { get; set; }
}
