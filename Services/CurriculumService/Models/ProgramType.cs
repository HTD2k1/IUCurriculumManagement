using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("program_type")]
public partial class ProgramType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    [StringLength(255)]
    public string Type { get; set; } = null!;

    [Column("description")]
    [StringLength(50)]
    public string? Description { get; set; }

    // [InverseProperty("ProgramType")]
    // public virtual ICollection<Program> Programs { get; } = new List<Program>();
}
