using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class TotalCreditsBySemesterItne
{
    public long Semester { get; set; }

    public decimal? Credits { get; set; }
}
