using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[PrimaryKey("ClassId", "AssessmentId")]
[Table("class_assessment_course")]
[Index("AssessmentId", Name = "fk_class_assessment_course_assessment")]
[Index("ClassId", Name = "fk_class_assessment_course_class")]
public partial class ClassAssessmentCourse
{
    [Key]
    [Column("class_id")]
    [StringLength(50)]
    public string ClassId { get; set; } = null!;

    [Key]
    [Column("assessment_id")]
    public int AssessmentId { get; set; }

    [Column("percentage")]
    public int? Percentage { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("ClassAssessmentCourses")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("ClassId")]
    [InverseProperty("ClassAssessmentCourses")]
    public virtual ClassSession Class { get; set; } = null!;
}
