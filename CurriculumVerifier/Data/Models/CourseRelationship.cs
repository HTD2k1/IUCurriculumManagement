using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Table("course_relationship")]
public partial class CourseRelationship
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("relationship")]
    [StringLength(255)]
    public string? Relationship { get; set; }
}
