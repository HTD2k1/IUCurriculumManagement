using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class AsiinClo
{
    public string Id { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<AsiinAssessmentTool> AsiinAssessmentTools { get; } = new List<AsiinAssessmentTool>();

    public virtual ICollection<AsiinCloslo> AsiinCloslos { get; } = new List<AsiinCloslo>();
}
