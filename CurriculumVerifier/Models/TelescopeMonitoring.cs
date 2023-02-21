using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Keyless]
[Table("telescope_monitoring")]
public partial class TelescopeMonitoring
{
    [Column("tag")]
    [StringLength(255)]
    public string Tag { get; set; } = null!;
}
