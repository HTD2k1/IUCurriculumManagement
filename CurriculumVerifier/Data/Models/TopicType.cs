using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class TopicType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual Topic IdNavigation { get; set; } = null!;
}
