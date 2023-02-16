using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class CourseRelationship
{
    public int Id { get; set; }

    public string? Relationship { get; set; }
}
