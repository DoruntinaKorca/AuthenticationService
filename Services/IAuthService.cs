using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Services
{
    public interface IAuthService
    {
        Task<string> UserLogin(LoginDto loginDto);
    }
}
