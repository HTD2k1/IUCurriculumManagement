using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CourseDepartment
{
    public string CourseId { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;
}
