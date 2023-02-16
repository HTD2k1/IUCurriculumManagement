﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Keyless]
[Table("course_course_relationship")]
[Index("RelationshipId", Name = "CourseCourse_CourseRelationship")]
[Index("CourseId2", Name = "FKCourse_Course2")]
[Index("CourseId1", "CourseId2", Name = "Key", IsUnique = true)]
public partial class CourseCourseRelationship
{
    [Column("course_id1")]
    public string CourseId1 { get; set; } = null!;

    [Column("course_id2")]
    public string CourseId2 { get; set; } = null!;

    [Column("relationship_id")]
    public int RelationshipId { get; set; }

    [ForeignKey("CourseId1")]
    public virtual Course CourseId1Navigation { get; set; } = null!;

    [ForeignKey("CourseId2")]
    public virtual Course CourseId2Navigation { get; set; } = null!;

    [ForeignKey("RelationshipId")]
    public virtual CourseRelationship Relationship { get; set; } = null!;
}
