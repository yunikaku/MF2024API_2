using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class ConferenceRoom
{
    public int ConferenceRoomId { get; set; }

    public string ConferenceRoomName { get; set; } = null!;

    public int ConferenceRoomCapacity { get; set; }

    public DateTime UpdateTime { get; set; }

    public string UpdateUser { get; set; } = null!;

    public virtual ICollection<ConferenceRoomReservation> ConferenceRoomReservations { get; set; } = new List<ConferenceRoomReservation>();

    public virtual ICollection<ConferenceRoomUse> ConferenceRoomUses { get; set; } = new List<ConferenceRoomUse>();

    public virtual User UpdateUserNavigation { get; set; } = null!;
}
