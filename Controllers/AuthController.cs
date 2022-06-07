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
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {

            _authService = authService;
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
