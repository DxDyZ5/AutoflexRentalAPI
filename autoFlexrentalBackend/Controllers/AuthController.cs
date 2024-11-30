using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autoFlexrentalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Endpoint to authenticate a user and generate a JWT token.
        /// </summary>
        /// <param name="request">An object containing the user's email and password.</param>
        /// <returns>A JWT token or an error message.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Email and password are required." });
            }

            // Authenticate user
            var user = _userService.Authenticate(request.Email, request.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            // Generate JWT token
            var token = _userService.GenerateJwt(user);

            return Ok(new
            {
                token,
                user = new
                {
                    user.UserId,
                    user.FullName,
                    user.Email,
                    user.PhoneNumber,
                    user.Role
                }
            });
        }
    }

}

