using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Course
{
    public string Id { get; set; } = null!;

    public int CourseLevelId { get; set; }

    public string? Name { get; set; }

    public string NameVn { get; set; } = null!;

    public int? CreditTheory { get; set; }

    public int? CreditLab { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<AsiinAssessmentTool> AsiinAssessmentTools { get; } = new List<AsiinAssessmentTool>();

    public virtual ICollection<ClassSession> ClassSessions { get; } = new List<ClassSession>();

    public virtual ICollection<CourseAssessment> CourseAssessments { get; } = new List<CourseAssessment>();

    public virtual ICollection<LearningOutcome> LearningOutcomes { get; } = new List<LearningOutcome>();

    public virtual ICollection<Topic> Topics { get; } = new List<Topic>();
}
