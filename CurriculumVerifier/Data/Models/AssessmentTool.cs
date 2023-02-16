using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Keyless]
[Table("assessment_tool")]
[Index("AssessmentId", "CourseId", Name = "FK_AssessmentTool_AssessmentCourse")]
[Index("LoutcomeId", Name = "FK_AssessmentTool_LOutcome")]
[Index("CourseId", "AssessmentId", "LoutcomeId", Name = "assessment_tool_id", IsUnique = true)]
public partial class AssessmentTool
{
    [Column("assessment_id")]
    public int AssessmentId { get; set; }

    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("loutcome_id")]
    public int LoutcomeId { get; set; }

    [Column("precentage")]
    public int? Precentage { get; set; }

    [ForeignKey("AssessmentId")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("CourseId")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("LoutcomeId")]
    public virtual LearningOutcome Loutcome { get; set; } = null!;
}
