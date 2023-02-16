using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Table("program_document")]
[Index("ProgramId", Name = "FK1_idx")]
[Index("DocumentId", Name = "FK2_idx")]
public partial class ProgramDocument
{
    [Column("program_id")]
    public int? ProgramId { get; set; }

    [Column("document_id")]
    public int? DocumentId { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("DocumentId")]
    [InverseProperty("ProgramDocuments")]
    public virtual Documentary? Document { get; set; }

    [ForeignKey("ProgramId")]
    [InverseProperty("ProgramDocuments")]
    public virtual Program? Program { get; set; }
}
