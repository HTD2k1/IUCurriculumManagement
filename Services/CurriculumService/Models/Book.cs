using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("book")]
public partial class Book
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("author")]
    [StringLength(255)]
    public string? Author { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string? Title { get; set; }

    [Column("version")]
    [StringLength(255)]
    public string? Version { get; set; }

    [Column("publisher")]
    [StringLength(255)]
    public string? Publisher { get; set; }

    [Column("year")]
    public int? Year { get; set; }

    [Column("ISBN")]
    [StringLength(255)]
    public string? Isbn { get; set; }

    [Column("type")]
    [StringLength(255)]
    public string? Type { get; set; }
}
