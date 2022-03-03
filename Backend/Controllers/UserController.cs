using Backend.Data.DTO.User;
using Backend.Interfaces;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _authRepo;
        public UserController(IUserService authRepository)
        {
            _authRepo = authRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(new User { Username = request.Username }, request.Password!);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                request.Username!, request.Password!);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}