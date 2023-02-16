using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Table("course_type")]
public partial class CourseType
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
}
