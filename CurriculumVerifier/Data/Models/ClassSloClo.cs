using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[PrimaryKey("ClassId", "CloId", "SloId")]
[Table("class_slo_clo")]
[Index("CloId", Name = "FKecnfqj0x90g694r9lpkch9v65")]
[Index("SloId", Name = "FKpfxxfwt6crqhsnjdhn8ltf4cu")]
public partial class ClassSloClo
{
    [Key]
    [Column("class_id")]
    [StringLength(50)]
    public string ClassId { get; set; } = null!;

    [Key]
    [Column("clo_id")]
    public int CloId { get; set; }

    [Key]
    [Column("slo_id")]
    public uint SloId { get; set; }

    [Column("percentage")]
    public float? Percentage { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("ClassSloClos")]
    public virtual ClassSession Class { get; set; } = null!;

    [ForeignKey("CloId")]
    [InverseProperty("ClassSloClos")]
    public virtual LearningOutcome Clo { get; set; } = null!;

    [ForeignKey("SloId")]
    [InverseProperty("ClassSloClos")]
    public virtual Slo Slo { get; set; } = null!;
}
