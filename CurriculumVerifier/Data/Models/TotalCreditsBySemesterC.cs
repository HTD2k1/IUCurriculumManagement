using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVerifier.Data.DataAnotationModels;

[Keyless]
public partial class TotalCreditsBySemesterC
{
    public long Semester { get; set; }

    [Precision(33, 0)]
    public decimal? Credits { get; set; }
}
