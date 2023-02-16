using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class DepartmentInstructor
{
    public int DepartmentId { get; set; }

    public string InstructorId { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual Instructor Instructor { get; set; } = null!;
}
