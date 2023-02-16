using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class TopicDetail
{
    public int Id { get; set; }

    public int TopicId { get; set; }

    public int? Week { get; set; }

    public string TopicDetail1 { get; set; } = null!;

    public virtual Topic Topic { get; set; } = null!;
}
