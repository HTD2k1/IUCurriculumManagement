using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("student")]
public partial class Student
{
    [Key]
    [Column("id")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("major")]
    [StringLength(45)]
    public string? Major { get; set; }

    [Column("batch")]
    public int? Batch { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<Result> Results { get; } = new List<Result>();
}
