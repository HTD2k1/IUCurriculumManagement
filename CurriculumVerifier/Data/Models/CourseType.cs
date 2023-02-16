using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CourseType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? TypeVn { get; set; }
}
