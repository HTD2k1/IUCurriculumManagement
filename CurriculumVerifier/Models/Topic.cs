using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("topic")]
[Index("CourseId", Name = "FK_Topic_Course")]
[Index("TopicTypeId", Name = "FK_topic_topic_type")]
public partial class Topic
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(510)]
    public string? Name { get; set; }

    [Column("teaching_activities")]
    [StringLength(255)]
    public string TeachingActivities { get; set; } = null!;

    [Column("learning_activities")]
    [StringLength(255)]
    public string LearningActivities { get; set; } = null!;

    [Column("topic_type_id")]
    public int TopicTypeId { get; set; }

    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [ForeignKey("CourseId")]
    [InverseProperty("Topics")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("Topic")]
    public virtual ICollection<TopicDetail> TopicDetails { get; } = new List<TopicDetail>();

    [InverseProperty("IdNavigation")]
    public virtual TopicType? TopicType { get; set; }
}
