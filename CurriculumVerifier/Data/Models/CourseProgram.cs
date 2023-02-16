using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CourseProgram
{
    public string CourseId { get; set; } = null!;

    public int ProgramId { get; set; }

    public string CourseCode { get; set; } = null!;

    public int CourseTypeId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual CourseType CourseType { get; set; } = null!;

    public virtual Program Program { get; set; } = null!;
}
