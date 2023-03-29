using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("learning_outcome")]
[Index("CourseId", Name = "FK_LearningOutcome")]
public partial class LearningOutcome
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string Description { get; set; } = null!;

    [Column("description_vn", TypeName = "text")]
    public string DescriptionVn { get; set; } = null!;

    [InverseProperty("LearningOutcome")]
    public virtual ICollection<ClassAssessment> ClassAssessments { get; } = new List<ClassAssessment>();

    [InverseProperty("Clo")]
    public virtual ICollection<ClassSloClo> ClassSloClos { get; } = new List<ClassSloClo>();

    [ForeignKey("CourseId")]
    [InverseProperty("LearningOutcomes")]
    public virtual Course Course { get; set; } = null!;
}
