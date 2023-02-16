using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Program
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Duration { get; set; }

    public string? Version { get; set; }

    public int? MajorId { get; set; }

    public int ProgramTypeId { get; set; }

    public string? ValidFrom { get; set; }

    public virtual Major? Major { get; set; }

    public virtual ICollection<ProgramDocument> ProgramDocuments { get; } = new List<ProgramDocument>();

    public virtual ProgramType ProgramType { get; set; } = null!;
}
