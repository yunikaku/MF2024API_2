using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class ConferenceRoomReservation
{
    public int ConferenceRoomReservationsId { get; set; }

    public int ConferenceRoomId { get; set; }

    public string UserId { get; set; } = null!;

    public string Requirement { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime ReservationTime { get; set; }

    public virtual ConferenceRoom ConferenceRoom { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
