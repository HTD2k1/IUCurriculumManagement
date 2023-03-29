using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("class")]
[Index("CourseId", "GroupTheory", "GroupLab", "Semester", "AcademicYear", Name = "course_id_group_theory_group_lab_semester_academic_year")]
public partial class Class
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("course_id")]
    [StringLength(50)]
    public string? CourseId { get; set; }

    [Column("group_theory")]
    public int? GroupTheory { get; set; }

    [Column("group_lab")]
    public int? GroupLab { get; set; }

    [Column("num_students")]
    public int? NumStudents { get; set; }

    [Column("instructor_id")]
    [StringLength(50)]
    public string? InstructorId { get; set; }

    [Column("semester")]
    public int? Semester { get; set; }

    [Column("academic_year")]
    [StringLength(50)]
    public string? AcademicYear { get; set; }
}
