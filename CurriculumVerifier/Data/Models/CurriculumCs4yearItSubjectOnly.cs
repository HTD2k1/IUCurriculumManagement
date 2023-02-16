using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CurriculumCs4yearItSubjectOnly
{
    public string CourseCode { get; set; } = null!;

    public string? CourseName { get; set; }

    public int? CreditTheory { get; set; }

    public int? CreditLab { get; set; }

    public string? Program { get; set; }

    public int Year { get; set; }

    public int Semester { get; set; }

    public string? Degree { get; set; }

    public string? Name { get; set; }
}
