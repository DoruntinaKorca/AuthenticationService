using System;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.DTOs;
using AuthenticationService.Models;
using Microsoft.AspNetCore.Identity;


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

        public async Task<string> GetIDFromToken(string tokenString)
        {
            var token = await _jwtService.Verify(tokenString);

            var claims = token.Payload.Claims;

            var userIdClaim = claims.Where(claim => claim.Type == "nameid").FirstOrDefault();

            return userIdClaim.Value;

        }

        /// <summary>
        /// Logs user in by creating a JWT token and embedding it in the client's cookies.
        /// </summary>
        /// <param name="loginDto">The data required to log the user in.</param>
        /// <returns>A JWT string token, ready to be appended.</returns>

        public async Task<string> UserLogin(LoginDto loginDto)
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

            return _jwtService.CreateToken(user);

        }
    }
}
