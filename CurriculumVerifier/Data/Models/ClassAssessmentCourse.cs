using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class ClassAssessmentCourse
{
    public string ClassId { get; set; } = null!;

    public int AssessmentId { get; set; }

    public int? Percentage { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual ClassSession Class { get; set; } = null!;
}
