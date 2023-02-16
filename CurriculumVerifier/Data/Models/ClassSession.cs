using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class ClassSession
{
    public string Id { get; set; } = null!;

    public string CourseId { get; set; } = null!;

    public int? Semester { get; set; }

    public string? AcademicYear { get; set; }

    public int? GroupTheory { get; set; }

    public virtual ICollection<ClassAssessmentCourse> ClassAssessmentCourses { get; } = new List<ClassAssessmentCourse>();

    public virtual ICollection<ClassAssessment> ClassAssessments { get; } = new List<ClassAssessment>();

    public virtual ICollection<ClassSloClo> ClassSloClos { get; } = new List<ClassSloClo>();

    public virtual Course Course { get; set; } = null!;
}
