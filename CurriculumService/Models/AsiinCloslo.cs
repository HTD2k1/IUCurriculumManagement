using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[PrimaryKey("CloId", "SloId")]
[Table("asiin_closlo")]
[Index("SloId", Name = "slo_closlo_asiin_idx")]
public partial class AsiinCloslo
{
    [Key]
    [Column("clo_id")]
    [StringLength(50)]
    public string CloId { get; set; } = null!;

    [Key]
    [Column("slo_id")]
    public uint SloId { get; set; }

    [Column("percentage")]
    public int? Percentage { get; set; }

    [Column("level")]
    public int? Level { get; set; }

    [ForeignKey("CloId")]
    [InverseProperty("AsiinCloslos")]
    public virtual AsiinClo Clo { get; set; } = null!;

    [ForeignKey("SloId")]
    [InverseProperty("AsiinCloslos")]
    public virtual Slo Slo { get; set; } = null!;
}
