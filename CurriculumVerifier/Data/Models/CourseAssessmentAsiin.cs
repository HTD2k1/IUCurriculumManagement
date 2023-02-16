using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[PrimaryKey("AssessmentId", "CourseId")]
[Table("course_assessment_asiin")]
[Index("CourseId", Name = "assessment_course_idx")]
public partial class CourseAssessmentAsiin
{
    [Key]
    [Column("assessment_id")]
    public int AssessmentId { get; set; }

    [Key]
    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("percentage")]
    public int? Percentage { get; set; }
}
