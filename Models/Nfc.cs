using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class Nfc
{
    public int NfcId { get; set; }

    public string NfcUid { get; set; }

    public DateTime AlloottedTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public string NfcPayload { get; set; } = null!;

    public int? ClientCompanyEmployeesId { get; set; }

    public int? NotReservationId { get; set; }

    public string UserId { get; set; } = null!;

    public virtual ClientCompanyEmployee ClientCompanyEmployees { get; set; } = null!;

    public virtual ICollection<EnteringAndLeaving> EnteringAndLeavings { get; set; } = new List<EnteringAndLeaving>();

    public virtual User User { get; set; } = null!;

    public virtual NotReservation NotReservation { get; set; } = null!;
}
