using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[PrimaryKey("CloId", "CourseId", "AssessmentId")]
[Table("asiin_assessment_tool")]
[Index("CourseId", Name = "FK_asiin_assessmentTool_course_idx")]
[Index("AssessmentId", Name = "FK_assessmentTool_assessment_idx")]
public partial class AsiinAssessmentTool
{
    [Key]
    [Column("clo_id")]
    [StringLength(50)]
    public string CloId { get; set; } = null!;

    [Key]
    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Key]
    [Column("assessment_id")]
    public int AssessmentId { get; set; }

    [Column("percentage")]
    public int? Percentage { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("AsiinAssessmentTools")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("CloId")]
    [InverseProperty("AsiinAssessmentTools")]
    public virtual AsiinClo Clo { get; set; } = null!;

    [ForeignKey("CourseId")]
    [InverseProperty("AsiinAssessmentTools")]
    public virtual Course Course { get; set; } = null!;
}
