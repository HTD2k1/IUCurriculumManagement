using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Keyless]
[Table("course_pathway")]
[Index("CourseId", Name = "FK_CoursePathway_Course")]
[Index("PathwayId", Name = "FK_CoursePathway_Pathway")]
[Index("ProgramId", "PathwayId", "CourseId", Name = "program_id", IsUnique = true)]
public partial class CoursePathway
{
    [Column("program_id")]
    public int ProgramId { get; set; }

    [Column("pathway_id")]
    public int PathwayId { get; set; }

    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("semester")]
    public int Semester { get; set; }

    [Column("year")]
    public int Year { get; set; }
    //
    // [ForeignKey("CourseId")]
    // public virtual Course Course { get; set; } = null!;
    //
    // [ForeignKey("PathwayId")]
    // public virtual Pathway Pathway { get; set; } = null!;
    //
    // [ForeignKey("ProgramId")]
    // public virtual Program Program { get; set; } = null!;
}
