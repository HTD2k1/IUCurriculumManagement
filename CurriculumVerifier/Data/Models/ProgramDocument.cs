using System;
using System.Collections.Generic;

namespace CurriculumVerifier.Data.Models;

public partial class ProgramDocument
{
    public int? ProgramId { get; set; }

    public int? DocumentId { get; set; }

    public int Id { get; set; }

    public virtual Documentary? Document { get; set; }

    public virtual Program? Program { get; set; }
}
