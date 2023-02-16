using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Major
{
    public int Id { get; set; }

    public int? DisciplineId { get; set; }

    public string? FullName { get; set; }

    public string? ShortName { get; set; }

    public virtual Discipline? Discipline { get; set; }

    public virtual ICollection<Program> Programs { get; } = new List<Program>();
}
