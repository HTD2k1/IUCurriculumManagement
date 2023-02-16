using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Slo
{
    public uint Id { get; set; }

    public string? Description { get; set; }

    public int? Criteria { get; set; }

    public virtual ICollection<AsiinCloslo> AsiinCloslos { get; } = new List<AsiinCloslo>();

    public virtual ICollection<ClassSloClo> ClassSloClos { get; } = new List<ClassSloClo>();
}
