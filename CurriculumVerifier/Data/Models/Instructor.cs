using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Table("instructor")]
public partial class Instructor
{
    [Key]
    [Column("id")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("degree")]
    [StringLength(255)]
    public string? Degree { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string? Email { get; set; }
}
