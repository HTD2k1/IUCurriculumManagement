using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Keyless]
[Table("clo_slo")]
[Index("LoId", Name = "fk_clo_slo_learning_outcome")]
[Index("SloId", Name = "fk_clo_slo_slo")]
public partial class CloSlo
{
    [Column("slo_id")]
    public uint SloId { get; set; }

    [Column("lo_id")]
    public int LoId { get; set; }

    [Column("percentage")]
    public int? Percentage { get; set; }

    [Column("level")]
    public int? Level { get; set; }

    [ForeignKey("LoId")]
    public virtual LearningOutcome Lo { get; set; } = null!;

    [ForeignKey("SloId")]
    public virtual Slo Slo { get; set; } = null!;
}
