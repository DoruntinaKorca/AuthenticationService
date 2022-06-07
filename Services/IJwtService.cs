using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.Models;

namespace AuthenticationService.Services
{
    public interface IJwtService
    {
        string CreateToken(User user);

        Task<JwtSecurityToken> Verify(string token);
    }
}
