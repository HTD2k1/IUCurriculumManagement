using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CurriculumCsAe18semester
{
    public long Semester { get; set; }

    public string CourseCode { get; set; } = null!;

    public string? CourseName { get; set; }

    public long? Credits { get; set; }
}
