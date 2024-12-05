using System.Runtime.InteropServices;
using autoFlexrentalBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly AutoFlexRentalContext _context;

    public AdminController(AutoFlexRentalContext context)
    {
        _context = context;
    }

    [HttpGet("analysis")]
    public async Task<IActionResult> GetAnalysis()
    {
        var analysis = await _context.Reservations
            .Include(r => r.Vehicle)
            .Include(r => r.User)
            .Select(r => new
            {
                VehicleModel = r.Vehicle.Model,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                RentedBy = r.User.FullName
            }).ToListAsync();

        return Ok(analysis);
    }
}
