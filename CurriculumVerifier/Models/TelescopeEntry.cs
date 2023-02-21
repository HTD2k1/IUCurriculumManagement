using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("telescope_entries")]
[Index("BatchId", Name = "telescope_entries_batch_id_index")]
[Index("CreatedAt", Name = "telescope_entries_created_at_index")]
[Index("FamilyHash", Name = "telescope_entries_family_hash_index")]
[Index("Type", "ShouldDisplayOnIndex", Name = "telescope_entries_type_should_display_on_index_index")]
[Index("Uuid", Name = "telescope_entries_uuid_unique", IsUnique = true)]
public partial class TelescopeEntry
{
    [Key]
    [Column("sequence")]
    public ulong Sequence { get; set; }

    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("batch_id")]
    public Guid BatchId { get; set; }

    [Column("family_hash")]
    public string? FamilyHash { get; set; }

    [Required]
    [Column("should_display_on_index")]
    public bool? ShouldDisplayOnIndex { get; set; }

    [Column("type")]
    [StringLength(20)]
    public string Type { get; set; } = null!;

    [Column("content")]
    public string Content { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
