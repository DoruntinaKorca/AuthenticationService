using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AuthenticationService.DTOs;
using AuthenticationService.Models;
using AuthenticationService.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/authenticationservice/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
     //   private readonly JwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(IAuthService authService, UserManager<User> userManager, SignInManager<User> signInManager)
        {

            _authService = authService;
         //  _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {

            string token = await _authService.UserLogin(loginDto);

            Response.Cookies.Append("jwt", token);

            return Ok();
        }

        [HttpPost("logout")]

        public IActionResult LogOut()
        {

            Response.Cookies.Delete("jwt");

            return Ok();

        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email taken");
            }
          
            var user = new User
            {
                UserName=registerDto.Username,
                Email = registerDto.Email
            };

            return Ok( await _userManager.CreateAsync(user, registerDto.Password));
    
        }

        [HttpGet("getIdClaim")]

        public async Task<ActionResult<string>> VerifyToken()
        {

            if (Request.Cookies["jwt"] == null) return Unauthorized();

            string userId = await _authService.GetIDFromToken(Request.Cookies["jwt"]);

            if (userId == null) return NotFound();

            return Ok(userId);

        }
    }


}
