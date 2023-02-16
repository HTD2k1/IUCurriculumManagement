using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class ProgramType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Program> Programs { get; } = new List<Program>();
}
