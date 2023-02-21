using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[PrimaryKey("StudentId", "ClassId")]
[Table("result")]
public partial class Result
{
    [Key]
    [Column("student_id")]
    [StringLength(50)]
    public string StudentId { get; set; } = null!;

    [Key]
    [Column("class_id")]
    public string ClassId { get; set; } = null!;

    [Column("mid_score")]
    public int? MidScore { get; set; }

    [Column("final_score")]
    public int? FinalScore { get; set; }

    [Column("in_class_score")]
    public int? InClassScore { get; set; }

    [Column("GPA")]
    public int? Gpa { get; set; }

    [Column("abet_score")]
    public int? AbetScore { get; set; }

    [Column("abet_1")]
    public int? Abet1 { get; set; }

    [Column("abet_2")]
    public int? Abet2 { get; set; }

    [Column("abet_3")]
    public int? Abet3 { get; set; }

    [Column("abet_4")]
    public int? Abet4 { get; set; }

    [Column("abet_5")]
    public int? Abet5 { get; set; }

    [Column("abet_6")]
    public int? Abet6 { get; set; }

    [Column("avg")]
    public float? Avg { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Results")]
    public virtual Student Student { get; set; } = null!;
}
