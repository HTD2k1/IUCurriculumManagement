using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Topic
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string TeachingActivities { get; set; } = null!;

    public string LearningActivities { get; set; } = null!;

    public int TopicTypeId { get; set; }

    public string CourseId { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<TopicDetail> TopicDetails { get; } = new List<TopicDetail>();

    public virtual TopicType? TopicType { get; set; }
}
