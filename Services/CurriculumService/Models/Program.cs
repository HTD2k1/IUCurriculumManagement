using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Expect;

namespace CurriculumService.Models;

[Table("program")]
[Index("MajorId", Name = "FK_program_major")]
[Index("ProgramTypeId", Name = "fk_program_program_type")]
public partial class Program
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("duration")]
    public int? Duration { get; set; }

    [Column("version")]
    [StringLength(4)]
    public string? Version { get; set; }

    [Column("major_id")]
    public int? MajorId { get; set; }

    [Column("program_type_id")]
    public int ProgramTypeId { get; set; }

    [Column("valid_from")]
    [StringLength(255)]
    public string? ValidFrom { get; set; }

    [ForeignKey("MajorId")]
    [InverseProperty("Programs")]
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Major? Major { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [InverseProperty("Program")]
    public virtual ICollection<ProgramDocument> ProgramDocuments { get; } = new List<ProgramDocument>();

    // [System.Text.Json.Serialization.JsonIgnore]
    // [ForeignKey("ProgramTypeId")]
    // [InverseProperty("Programs")]
    // public virtual ProgramType ProgramType { get; set; } = null!;
}
