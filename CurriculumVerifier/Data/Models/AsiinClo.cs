using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Table("asiin_clo")]
public partial class AsiinClo
{
    [Key]
    [Column("id")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [InverseProperty("Clo")]
    public virtual ICollection<AsiinAssessmentTool> AsiinAssessmentTools { get; } = new List<AsiinAssessmentTool>();

    [InverseProperty("Clo")]
    public virtual ICollection<AsiinCloslo> AsiinCloslos { get; } = new List<AsiinCloslo>();
}
