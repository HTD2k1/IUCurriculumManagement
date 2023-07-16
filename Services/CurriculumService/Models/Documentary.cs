using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("documentary")]
[Index("DocumentId", Name = "document_id_UNIQUE", IsUnique = true)]
public partial class Documentary
{
    [Column("document_id")]
    [StringLength(50)]
    public string DocumentId { get; set; } = null!;

    [Column("name")]
    [StringLength(200)]
    public string? Name { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    // [InverseProperty("Document")]
    // public virtual ICollection<ProgramDocument> ProgramDocuments { get; } = new List<ProgramDocument>();
}
