using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class EmployeeReservation
{
    public int EmployeeReservationsId { get; set; }

    public string UserId { get; set; } = null!;

    public int ClientCompanyEmployeesId { get; set; }

    public DateTime ReservationsTime { get; set; }

    public byte[] Qr { get; set; } = null!;

    public string CompleteFlag { get; set; } = null!;

    public string Requirement { get; set; } = null!;

    public virtual ClientCompanyEmployee ClientCompanyEmployees { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
