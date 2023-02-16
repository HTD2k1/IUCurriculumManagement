using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Author { get; set; }

    public string? Title { get; set; }

    public string? Version { get; set; }

    public string? Publisher { get; set; }

    public int? Year { get; set; }

    public string? Isbn { get; set; }

    public string? Type { get; set; }
}
