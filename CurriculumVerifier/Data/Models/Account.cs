using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? Password { get; set; }

    public string? UserName { get; set; }

    public string? UserRole { get; set; }

    public int? InstructorId { get; set; }
}
