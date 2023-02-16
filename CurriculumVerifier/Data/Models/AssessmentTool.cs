using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class AssessmentTool
{
    public int AssessmentId { get; set; }

    public string CourseId { get; set; } = null!;

    public int LoutcomeId { get; set; }

    public int? Precentage { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual LearningOutcome Loutcome { get; set; } = null!;
}
