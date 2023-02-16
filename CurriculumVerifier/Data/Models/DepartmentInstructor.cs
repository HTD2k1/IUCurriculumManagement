using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.Models;

[Keyless]
[Table("department_instructor")]
[Index("InstructorId", Name = "FK_DepartmentInstructor_Instructor")]
[Index("DepartmentId", "InstructorId", Name = "department_instructor_key", IsUnique = true)]
public partial class DepartmentInstructor
{
    [Column("department_id")]
    public int DepartmentId { get; set; }

    [Column("instructor_id")]
    [StringLength(50)]
    public string InstructorId { get; set; } = null!;

    [ForeignKey("DepartmentId")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("InstructorId")]
    public virtual Instructor Instructor { get; set; } = null!;
}
