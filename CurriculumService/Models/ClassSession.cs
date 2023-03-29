using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("class_session")]
[Index("CourseId", Name = "FK_classSession_course")]
public partial class ClassSession
{
    [Key]
    [Column("id")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("semester")]
    public int? Semester { get; set; }

    [Column("academic_year")]
    [StringLength(255)]
    public string? AcademicYear { get; set; }

    [Column("group_theory")]
    public int? GroupTheory { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<ClassAssessmentCourse> ClassAssessmentCourses { get; } = new List<ClassAssessmentCourse>();

    [InverseProperty("Class")]
    public virtual ICollection<ClassAssessment> ClassAssessments { get; } = new List<ClassAssessment>();

    [InverseProperty("Class")]
    public virtual ICollection<ClassSloClo> ClassSloClos { get; } = new List<ClassSloClo>();

    [ForeignKey("CourseId")]
    [InverseProperty("ClassSessions")]
    public virtual Course Course { get; set; } = null!;
}
