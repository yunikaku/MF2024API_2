using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MF2024API_2.Models;

public partial class ClientCompany
{
    public int ClientCompanyId { get; set; }

    public string ClientCompanyName { get; set; } = null!;

    public string ClientCompanyEmail { get; set; } = null!;

    public string ClientCompanyPhoneNumber { get; set; } = null!;

    public string ClientCompanyAddress { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<ClientCompanyEmployee> ClientCompanyEmployees { get; set; } = new List<ClientCompanyEmployee>();
}
