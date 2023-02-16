using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Documentary
{
    public string DocumentId { get; set; } = null!;

    public string? Name { get; set; }

    public int Id { get; set; }

    public virtual ICollection<ProgramDocument> ProgramDocuments { get; } = new List<ProgramDocument>();
}
