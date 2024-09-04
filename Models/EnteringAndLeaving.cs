using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class EnteringAndLeaving
{
    public int EnteringAndLeavingId { get; set; }

    public DateTime EnteringAndLeavingAdmissionTime { get; set; }

    public DateTime EnteringAndLeavingExitTime { get; set; }

    public int DeviceId { get; set; }

    public int StatusId { get; set; }

    public int NfcId { get; set; }

    public int CompleteFlg { get; set; }

    public string UserId { get; set; }

    public int ClientCompanyEmployeesId { get; set; }

    public virtual ClientCompanyEmployee ClientCompanyEmployees { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Device Device { get; set; } = null!;

    public virtual Nfc Nfc { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
