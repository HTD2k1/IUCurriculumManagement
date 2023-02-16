using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Table("assessment")]
public partial class Assessment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    [StringLength(255)]
    public string? Type { get; set; }

    [Column("type_vn")]
    [StringLength(255)]
    public string? TypeVn { get; set; }

    [InverseProperty("Assessment")]
    public virtual ICollection<AsiinAssessmentTool> AsiinAssessmentTools { get; } = new List<AsiinAssessmentTool>();

    [InverseProperty("Assessment")]
    public virtual ICollection<ClassAssessmentCourse> ClassAssessmentCourses { get; } = new List<ClassAssessmentCourse>();

    [InverseProperty("Assessment")]
    public virtual ICollection<ClassAssessment> ClassAssessments { get; } = new List<ClassAssessment>();
}
