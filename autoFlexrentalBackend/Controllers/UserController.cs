using System.Runtime.InteropServices;

using Microsoft.AspNetCore.Mvc;
using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Models;


using System.Threading.Tasks;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly AutoFlexRentalContext _context;

    public UserController(AutoFlexRentalContext context)
    {
        _context = context;
    }

    // POST: api/users
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User
        {
            FullName = userDto.FullName,
            Email = userDto.Email,
            PhoneNumber = userDto.PhoneNumber,
            PasswordHash = userDto.PasswordHash,
            Role = userDto.Role,
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(userDto);
    }

    // PUT: api/users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        user.FullName = userDto.FullName;
        user.Email = userDto.Email;
        user.PhoneNumber = userDto.PhoneNumber;
        user.PasswordHash = userDto.PasswordHash;
        user.Role = userDto.Role;

        await _context.SaveChangesAsync();

        return Ok(userDto);
    }

    // DELETE: api/users/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
