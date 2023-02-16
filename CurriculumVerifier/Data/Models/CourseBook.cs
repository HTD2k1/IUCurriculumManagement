using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CourseBook
{
    public int BookId { get; set; }

    public string CourseId { get; set; } = null!;

    public string? Type { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
