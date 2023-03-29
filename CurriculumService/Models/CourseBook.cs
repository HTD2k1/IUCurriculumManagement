using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Keyless]
[Table("course_book")]
[Index("CourseId", Name = "FK_BookCourse_Course")]
[Index("BookId", "CourseId", Name = "Key", IsUnique = true)]
public partial class CourseBook
{
    [Column("book_id")]
    public int BookId { get; set; }

    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("type")]
    [StringLength(255)]
    public string? Type { get; set; }

    [ForeignKey("BookId")]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey("CourseId")]
    public virtual Course Course { get; set; } = null!;
}
