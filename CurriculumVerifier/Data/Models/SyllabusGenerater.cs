using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class SyllabusGenerater
{
    public string CourseId { get; set; } = null!;

    public string Vietnamese { get; set; } = null!;

    public string? English { get; set; }

    public int? Lecturer { get; set; }

    public int? Laborator { get; set; }

    public long? TotalCredit { get; set; }

    public string Description { get; set; } = null!;

    public string? CourseType { get; set; }

    public string? IntructorName { get; set; }

    public string? Department { get; set; }

    public string? Email { get; set; }
}
