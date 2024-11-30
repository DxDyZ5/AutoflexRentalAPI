using autoFlexrentalBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autoFlexrentalBackend.Controllers
{
    [ApiController]
    [Route("api/Search")]
    public class VehicleSearchController : Controller
    {
        private readonly IVehicleSearchService _vehicleSearchService;

        public VehicleSearchController(IVehicleSearchService vehicleSearchService)
        {
            _vehicleSearchService = vehicleSearchService;
        }

        // Advance search Endpoint vehicles Service
        [HttpGet]
        public IActionResult SearchVehicles(
            [FromQuery] string? brand = null,
            [FromQuery] string? model = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null)
        {
            // Fetch the vehicles list filtered
            var vehicles = _vehicleSearchService.SearchVehicles(brand, model, minPrice, maxPrice);

            // If doesn't find any
            if (vehicles == null || !vehicles.Any())
            {
                return NotFound("No vehicles found with the given search criteria.");
            }

            return Ok(vehicles); // Return the vehicles filtered
        }
    }
}


