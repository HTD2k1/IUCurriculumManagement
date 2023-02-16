using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[PrimaryKey("AssessmentId", "CourseId")]
[Table("course_assessment")]
[Index("CourseId", Name = "Fk_AssessmentCourse_Course")]
public partial class CourseAssessment
{
    [Key]
    [Column("assessment_id")]
    public int AssessmentId { get; set; }

    [Key]
    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("percentage")]
    public int Percentage { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("CourseAssessments")]
    public virtual Course Course { get; set; } = null!;
}
