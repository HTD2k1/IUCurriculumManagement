using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[PrimaryKey("AssessmentId", "ClassId", "LearningOutcomeId")]
[Table("class_assessment")]
[Index("LearningOutcomeId", Name = "FKgvbc7qhba0d7odssq6rtompih")]
[Index("ClassId", Name = "FKmevtb7furfoqcnjqn5wuafdx5")]
public partial class ClassAssessment
{
    [Key]
    [Column("assessment_id")]
    public int AssessmentId { get; set; }

    [Key]
    [Column("class_id")]
    [StringLength(50)]
    public string ClassId { get; set; } = null!;

    [Key]
    [Column("learning_outcome_id")]
    public int LearningOutcomeId { get; set; }

    [Column("precentage")]
    public float? Precentage { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("ClassAssessments")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("ClassId")]
    [InverseProperty("ClassAssessments")]
    public virtual ClassSession Class { get; set; } = null!;

    [ForeignKey("LearningOutcomeId")]
    [InverseProperty("ClassAssessments")]
    public virtual LearningOutcome LearningOutcome { get; set; } = null!;
}
