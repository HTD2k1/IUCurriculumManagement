using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CurriculumService.Models;

[Table("pathway")]
public partial class Pathway
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("pathway")]
    [StringLength(255)]
    public string Pathway1 { get; set; } = null!;
}
