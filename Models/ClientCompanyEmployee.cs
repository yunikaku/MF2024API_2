using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MF2024API_2.Models;

public partial class ClientCompanyEmployee
{
    public int ClientCompanyEmployeesId { get; set; }

    public int? ClientCompanyId { get; set; }

    public string ClientCompanyEmployeesName { get; set; } = null!;

    public string ClientCompanyEmployeesNameKana { get; set; } = null!;

    public string ClientCompanyEmployeesEmail { get; set; } = null!;

    public string ClientCompanyEmployeesPhoneNumber { get; set; } = null!;

    public string ClientCompanyEmployeesSection { get; set; } = null!;

    public string ClientCompanyEmployeesPosition { get; set; } = null!;

    
    public virtual ClientCompany ClientCompany { get; set; } = null!;
    
    public virtual ICollection<EmployeeReservation> EmployeeReservations { get; set; } = new List<EmployeeReservation>();
    
    public virtual ICollection<Nfc> Nfcs { get; set; } = new List<Nfc>();
    
    public virtual ICollection<EnteringAndLeaving> EnteringAndLeavings { get; set; } = new List<EnteringAndLeaving>();
}
