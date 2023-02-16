using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Assessment
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? TypeVn { get; set; }

    public virtual ICollection<AsiinAssessmentTool> AsiinAssessmentTools { get; } = new List<AsiinAssessmentTool>();

    public virtual ICollection<ClassAssessmentCourse> ClassAssessmentCourses { get; } = new List<ClassAssessmentCourse>();

    public virtual ICollection<ClassAssessment> ClassAssessments { get; } = new List<ClassAssessment>();
}
