using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MF2024API_2.Models;

namespace MF2024API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user,IList<string> roles);
    }
}