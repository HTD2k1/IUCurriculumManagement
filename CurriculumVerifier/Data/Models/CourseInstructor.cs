using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Keyless]
[Table("course_instructor")]
[Index("InstructorId", Name = "FK_CourseInstructor_Instructor")]
[Index("CourseId", "InstructorId", Name = "course_id", IsUnique = true)]
public partial class CourseInstructor
{
    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("instructor_id")]
    public int InstructorId { get; set; }

    [ForeignKey("CourseId")]
    public virtual Course Course { get; set; } = null!;
}
