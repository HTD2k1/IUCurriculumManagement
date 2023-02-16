using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Instructor
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Degree { get; set; }

    public string? Email { get; set; }
}
