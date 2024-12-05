using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using autoFlexrentalBackend.Models;

namespace autoFlexrentalBackend.Controllers
{
    [ApiController]
    [Route("api/analysis")]
    public class AnalysisController : ControllerBase
    {
        private readonly AutoFlexRentalContext _context;

        public AnalysisController(AutoFlexRentalContext context)
        {
            _context = context;
        }

        [HttpGet]
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
}
