using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Table("slo")]
public partial class Slo
{
    [Key]
    [Column("id")]
    public uint Id { get; set; }

    [Column("description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("criteria")]
    public int? Criteria { get; set; }

    [InverseProperty("Slo")]
    public virtual ICollection<AsiinCloslo> AsiinCloslos { get; } = new List<AsiinCloslo>();

    [InverseProperty("Slo")]
    public virtual ICollection<ClassSloClo> ClassSloClos { get; } = new List<ClassSloClo>();
}
