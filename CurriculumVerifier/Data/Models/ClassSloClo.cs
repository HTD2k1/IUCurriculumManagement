using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class ClassSloClo
{
    public string ClassId { get; set; } = null!;

    public int CloId { get; set; }

    public uint SloId { get; set; }

    public float? Percentage { get; set; }

    public virtual ClassSession Class { get; set; } = null!;

    public virtual LearningOutcome Clo { get; set; } = null!;

    public virtual Slo Slo { get; set; } = null!;
}
