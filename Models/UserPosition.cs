using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class UserPosition
{
    public string UserId { get; set; } = null!;

    public int SectionId { get; set; }

    public DateTime UpdateTime { get; set; }

    public string UserPositionUpdateUser { get; set; } = null!;

    public string RoleId { get; set; } = null!;
}
