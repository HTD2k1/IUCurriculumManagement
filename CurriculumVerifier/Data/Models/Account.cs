using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Table("account")]
[Index("InstructorId", Name = "FK9nkqtsydmph5nrsd3sn1f4w29")]
public partial class Account
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("password")]
    [StringLength(255)]
    public string? Password { get; set; }

    [Column("user_name")]
    [StringLength(255)]
    public string? UserName { get; set; }

    [Column("user_role")]
    [StringLength(255)]
    public string? UserRole { get; set; }

    [Column("instructor_id")]
    public int? InstructorId { get; set; }
}
