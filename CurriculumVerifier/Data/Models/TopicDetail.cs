using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Table("topic_detail")]
[Index("TopicId", Name = "FK_topic_TopicDetail")]
public partial class TopicDetail
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("topic_id")]
    public int TopicId { get; set; }

    [Column("week")]
    public int? Week { get; set; }

    [Column("topic_detail")]
    [StringLength(1000)]
    public string TopicDetail1 { get; set; } = null!;

    [ForeignKey("TopicId")]
    [InverseProperty("TopicDetails")]
    public virtual Topic Topic { get; set; } = null!;
}
