using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class LearningOutcome
{
    public int Id { get; set; }

    public string CourseId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string DescriptionVn { get; set; } = null!;

    public virtual ICollection<ClassAssessment> ClassAssessments { get; } = new List<ClassAssessment>();

    public virtual ICollection<ClassSloClo> ClassSloClos { get; } = new List<ClassSloClo>();

    public virtual Course Course { get; set; } = null!;
}
