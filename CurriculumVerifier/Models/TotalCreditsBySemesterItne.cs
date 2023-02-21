﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Keyless]
public partial class TotalCreditsBySemesterItne
{
    public long Semester { get; set; }

    [Precision(33, 0)]
    public decimal? Credits { get; set; }
}
