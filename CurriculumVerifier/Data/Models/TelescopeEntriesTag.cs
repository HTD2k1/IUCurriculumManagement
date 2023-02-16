using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Keyless]
[Table("telescope_entries_tags")]
[Index("EntryUuid", "Tag", Name = "telescope_entries_tags_entry_uuid_tag_index")]
[Index("Tag", Name = "telescope_entries_tags_tag_index")]
public partial class TelescopeEntriesTag
{
    [Column("entry_uuid")]
    public Guid EntryUuid { get; set; }

    [Column("tag")]
    public string Tag { get; set; } = null!;

    public virtual TelescopeEntry EntryUu { get; set; } = null!;
}
