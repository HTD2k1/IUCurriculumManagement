using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("course")]
[Index("CourseLevelId", Name = "FK_Course_CourseLevel")]
public partial class Course
{
    [Key]
    [Column("id")]
    public string Id { get; set; } = null!;

    [Column("course_level_id")]
    public int CourseLevelId { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("name_vn")]
    [StringLength(255)]
    public string NameVn { get; set; } = null!;

    [Column("credit_theory")]
    public int? CreditTheory { get; set; }

    [Column("credit_lab")]
    public int? CreditLab { get; set; }

    [Column("description", TypeName = "text")]
    public string Description { get; set; } = null!;
    
    [System.Text.Json.Serialization.JsonIgnore(Condition=JsonIgnoreCondition.Always)]
    [InverseProperty("Course")]
    public virtual ICollection<AsiinAssessmentTool> AsiinAssessmentTools { get; } = new List<AsiinAssessmentTool>();
    
    [System.Text.Json.Serialization.JsonIgnore(Condition=JsonIgnoreCondition.Always)]
    [InverseProperty("Course")]
    public virtual ICollection<ClassSession> ClassSessions { get; } = new List<ClassSession>();
    
    [System.Text.Json.Serialization.JsonIgnore(Condition=JsonIgnoreCondition.Always)]
    [InverseProperty("Course")]
    public virtual ICollection<CourseAssessment> CourseAssessments { get; } = new List<CourseAssessment>();
    [System.Text.Json.Serialization.JsonIgnore(Condition=JsonIgnoreCondition.Always)]
    [InverseProperty("Course")]
    public virtual ICollection<LearningOutcome> LearningOutcomes { get; } = new List<LearningOutcome>();
    
    [System.Text.Json.Serialization.JsonIgnore(Condition=JsonIgnoreCondition.Always)]
    [InverseProperty("Course")]
    public virtual ICollection<Topic> Topics { get; } = new List<Topic>();
}
