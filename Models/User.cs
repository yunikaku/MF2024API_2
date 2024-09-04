using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MF2024API_2.Models;

public partial class User : IdentityUser
{

    public string UserSlackId { get; set; } = null!;

    public string UserSlackUrl { get; set; } = null!;

    public DateTime UserPasswoedUpdataTime { get; set; }

    public DateTime UserDateOfBirth { get; set; }

    public string UserNameKana { get; set; } = null!;

    public string UserGender { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public string UserIndustry { get; set; } = null!;

    public DateTime UserDateOfEntry { get; set; }

    public DateTime UserDateOfRetirement { get; set; }

    public DateTime UserUpdataDate { get; set; }

    public string UserUpdataUser { get; set; } = null!;
    public virtual ICollection<ConferenceRoomReservation> ConferenceRoomReservations { get; set; } = new List<ConferenceRoomReservation>();

    public virtual ICollection<ConferenceRoomUse> ConferenceRoomUses { get; set; } = new List<ConferenceRoomUse>();

    public virtual ICollection<ConferenceRoom> ConferenceRooms { get; set; } = new List<ConferenceRoom>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual ICollection<EmployeeReservation> EmployeeReservations { get; set; } = new List<EmployeeReservation>();

    public virtual ICollection<Nfc> Nfcs { get; set; } = new List<Nfc>();

    public virtual ICollection<EnteringAndLeaving> EnteringAndLeavings { get; set; } = new List<EnteringAndLeaving>();
}
