using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Keyless]
public partial class SyllabusGenerater
{
    [Column("CourseID")]
    [StringLength(255)]
    public string CourseId { get; set; } = null!;

    [StringLength(255)]
    public string Vietnamese { get; set; } = null!;

    [StringLength(255)]
    public string? English { get; set; }

    public int? Lecturer { get; set; }

    public int? Laborator { get; set; }

    [Column("totalCredit")]
    public long? TotalCredit { get; set; }

    [Column("description", TypeName = "text")]
    public string Description { get; set; } = null!;

    [Column("Course Type")]
    [StringLength(255)]
    public string? CourseType { get; set; }

    [Column("Intructor Name")]
    [StringLength(512)]
    public string? IntructorName { get; set; }

    [StringLength(255)]
    public string? Department { get; set; }

    [StringLength(255)]
    public string? Email { get; set; }
}
