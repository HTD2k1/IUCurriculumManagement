using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CloSlo
{
    public uint SloId { get; set; }

    public int LoId { get; set; }

    public int? Percentage { get; set; }

    public int? Level { get; set; }

    public virtual LearningOutcome Lo { get; set; } = null!;

    public virtual Slo Slo { get; set; } = null!;
}
