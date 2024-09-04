using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string DepartmentSlackId { get; set; } = null!;

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
