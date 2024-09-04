using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string SectionName { get; set; } = null!;

    public string SectionSlackId { get; set; } = null!;

    public string SectionSlakUrl { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
}
