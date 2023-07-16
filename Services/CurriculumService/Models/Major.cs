using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("major")]
[Index("DisciplineId", Name = "FK_major_discipline")]
public partial class Major
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("discipline_id")]
    public int? DisciplineId { get; set; }

    [Column("full_name")]
    [StringLength(255)]
    public string? FullName { get; set; }

    [Column("short_name")]
    [StringLength(255)]
    public string? ShortName { get; set; }

    [ForeignKey("DisciplineId")]
    [InverseProperty("Majors")]
    public virtual Discipline? Discipline { get; set; }

    // [InverseProperty("Major")]
    // public virtual ICollection<Program> Programs { get; } = new List<Program>();
}
