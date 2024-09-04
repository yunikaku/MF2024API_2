using System;
using System.Collections.Generic;

namespace MF2024API_2.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPosition { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string CompanySlakId { get; set; } = null!;

    public int StandardWorkingHours { get; set; }

    public DateTime DateOfGrantWithPay { get; set; }

    public DateTime FirstDayOfTheCalendarYear { get; set; }

    public DateTime UpdateTime { get; set; }

    public string UpdateUser { get; set; } = null!;
}
