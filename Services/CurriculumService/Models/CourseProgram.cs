using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("course_program")]
[Index("CourseTypeId", Name = "FK_CourseProgram_CourseType")]
[Index("ProgramId", Name = "FK_CourseProgram_Program")]
[Index("CourseId", "ProgramId", Name = "Key", IsUnique = true)]
public partial class CourseProgram
{
    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("program_id")]
    public int ProgramId { get; set; }

    [Column("course_code")]
    [StringLength(255)]
    public string CourseCode { get; set; } = null!;
    [Column("course_type_id")]
    public int CourseTypeId { get; set; }
    
    // [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // public virtual Course? Course { get; set; }
    // [System.Text.Json.Serialization.JsonIgnore]
    // public virtual CourseType? CourseType { get; set; } = null!;
    // [System.Text.Json.Serialization.JsonIgnore]
    // public virtual Program? Program { get; set; } = null!;
    
}
