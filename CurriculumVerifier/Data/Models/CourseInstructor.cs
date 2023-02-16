using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CourseInstructor
{
    public string CourseId { get; set; } = null!;

    public int InstructorId { get; set; }

    public virtual Course Course { get; set; } = null!;
}
