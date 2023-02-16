using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class ClassAssessment
{
    public int AssessmentId { get; set; }

    public string ClassId { get; set; } = null!;

    public int LearningOutcomeId { get; set; }

    public float? Precentage { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual ClassSession Class { get; set; } = null!;

    public virtual LearningOutcome LearningOutcome { get; set; } = null!;
}
