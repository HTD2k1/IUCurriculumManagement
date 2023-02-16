using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CourseCourseRelationship
{
    public string CourseId1 { get; set; } = null!;

    public string CourseId2 { get; set; } = null!;

    public int RelationshipId { get; set; }

    public virtual Course CourseId1Navigation { get; set; } = null!;

    public virtual Course CourseId2Navigation { get; set; } = null!;

    public virtual CourseRelationship Relationship { get; set; } = null!;
}
