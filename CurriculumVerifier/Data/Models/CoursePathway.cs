using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CoursePathway
{
    public int ProgramId { get; set; }

    public int PathwayId { get; set; }

    public string CourseId { get; set; } = null!;

    public int Semester { get; set; }

    public int Year { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Pathway Pathway { get; set; } = null!;

    public virtual Program Program { get; set; } = null!;
}
