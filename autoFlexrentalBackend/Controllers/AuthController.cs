using System.Runtime.InteropServices;
using autoFlexrentalBackend.Models;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AutoFlexRentalContext _context;

    public AuthController(AutoFlexRentalContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var user = _context.Users.SingleOrDefault(u => u.Email == loginDto.Email);

        if (user == null || user.PasswordHash != loginDto.Password)
        {
            return Unauthorized(new { message = "Credenciales inválidas" });
        }

        // Generar un token (simulación, agrega JWT en un entorno real)
        var token = Guid.NewGuid().ToString();

        return Ok(new
        {
            token = token,
            role = user.Role
        });
    }
}
