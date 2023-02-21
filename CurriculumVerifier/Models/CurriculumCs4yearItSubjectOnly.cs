using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Keyless]
public partial class CurriculumCs4yearItSubjectOnly
{
    [Column("course_code")]
    [StringLength(255)]
    public string CourseCode { get; set; } = null!;

    [Column("Course Name")]
    [StringLength(255)]
    public string? CourseName { get; set; }

    [Column("credit_theory")]
    public int? CreditTheory { get; set; }

    [Column("credit_lab")]
    public int? CreditLab { get; set; }

    [StringLength(255)]
    public string? Program { get; set; }

    [Column("year")]
    public int Year { get; set; }

    [Column("semester")]
    public int Semester { get; set; }

    [Column("degree")]
    [StringLength(255)]
    public string? Degree { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }
}
