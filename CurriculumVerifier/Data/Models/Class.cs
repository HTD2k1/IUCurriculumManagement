using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Class
{
    public int Id { get; set; }

    public string? CourseId { get; set; }

    public int? GroupTheory { get; set; }

    public int? GroupLab { get; set; }

    public int? NumStudents { get; set; }

    public string? InstructorId { get; set; }

    public int? Semester { get; set; }

    public string? AcademicYear { get; set; }
}
