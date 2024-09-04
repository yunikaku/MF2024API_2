using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class Device
{
    public int DeviceId { get; set; }

    public string DeviceName { get; set; } = null!;

    public string DeviceLocation { get; set; } = null!;

    public DateTime CreationTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public string DeviceUpdateUserID { get; set; } = null!;

    public virtual User DeviceUpdateUserNavigation { get; set; } = null!;

    public virtual ICollection<EnteringAndLeaving> EnteringAndLeavings { get; set; } = new List<EnteringAndLeaving>();
}
