using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class AsiinAssessmentTool
{
    public string CloId { get; set; } = null!;

    public string CourseId { get; set; } = null!;

    public int AssessmentId { get; set; }

    public int? Percentage { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual AsiinClo Clo { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
