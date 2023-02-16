using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CourseAssessmentAsiin
{
    public int AssessmentId { get; set; }

    public string CourseId { get; set; } = null!;

    public int? Percentage { get; set; }
}
