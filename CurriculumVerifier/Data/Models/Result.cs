using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Result
{
    public string StudentId { get; set; } = null!;

    public string ClassId { get; set; } = null!;

    public int? MidScore { get; set; }

    public int? FinalScore { get; set; }

    public int? InClassScore { get; set; }

    public int? Gpa { get; set; }

    public int? AbetScore { get; set; }

    public int? Abet1 { get; set; }

    public int? Abet2 { get; set; }

    public int? Abet3 { get; set; }

    public int? Abet4 { get; set; }

    public int? Abet5 { get; set; }

    public int? Abet6 { get; set; }

    public float? Avg { get; set; }

    public virtual Student Student { get; set; } = null!;
}
