using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class AsiinCloslo
{
    public string CloId { get; set; } = null!;

    public uint SloId { get; set; }

    public int? Percentage { get; set; }

    public int? Level { get; set; }

    public virtual AsiinClo Clo { get; set; } = null!;

    public virtual Slo Slo { get; set; } = null!;
}
