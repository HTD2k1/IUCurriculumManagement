using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("topic_type")]
public partial class TopicType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    [StringLength(255)]
    public string? Type { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("TopicType")]
    public virtual Topic IdNavigation { get; set; } = null!;
}
