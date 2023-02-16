using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Table("course_level")]
public partial class CourseLevel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("level")]
    [StringLength(255)]
    public string? Level { get; set; }
}
