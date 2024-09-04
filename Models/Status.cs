using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusName { get; set; }

    public virtual ICollection<EnteringAndLeaving> EnteringAndLeavings { get; set; } = new List<EnteringAndLeaving>();
}
