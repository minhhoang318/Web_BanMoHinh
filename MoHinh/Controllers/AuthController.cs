﻿using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
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

        // POST: api/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var token = await _authService.AuthenticateAsync(request.Username, request.Password);
            if (token == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(new AuthenticateDTO { Token = token });
        }
    }
}
