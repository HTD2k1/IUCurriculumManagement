using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Student
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Major { get; set; }

    public int? Batch { get; set; }

    public virtual ICollection<Result> Results { get; } = new List<Result>();
}
