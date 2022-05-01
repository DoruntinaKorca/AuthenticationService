using AuthenticationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Services
{
    public interface IAuthService
    {
       Task<UserDto> UserLogin(LoginDto loginDto);
    }
}
