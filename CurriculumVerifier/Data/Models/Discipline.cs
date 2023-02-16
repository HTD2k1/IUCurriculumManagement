using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Discipline
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Major> Majors { get; } = new List<Major>();
}
