using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Keyless]
[Table("course_department")]
[Index("DepartmentId", Name = "FK_CourseDepartment_Department")]
[Index("CourseId", "DepartmentId", Name = "coruse_id", IsUnique = true)]
public partial class CourseDepartment
{
    [Column("course_id")]
    public string CourseId { get; set; } = null!;

    [Column("department_id")]
    public int DepartmentId { get; set; }

    [ForeignKey("CourseId")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("DepartmentId")]
    public virtual Department Department { get; set; } = null!;
}
