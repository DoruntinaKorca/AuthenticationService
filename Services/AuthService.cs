using AuthenticationService.DTOs;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;
        public AuthService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtService jwtService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<UserDto> UserLogin(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                throw new ArgumentException();
            }

            return new UserDto
            {
                Token = _jwtService.CreateToken(user)

            };

        }
    }
}
