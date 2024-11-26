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

        // Endpoint para búsqueda avanzada de vehículos
        [HttpGet]
        public IActionResult SearchVehicles(
            [FromQuery] string? brand = null,
            [FromQuery] string? model = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null)
        {
            // Obtener la lista de vehículos filtrados
            var vehicles = _vehicleSearchService.SearchVehicles(brand, model, minPrice, maxPrice);

            // Si no se encuentran vehículos
            if (vehicles == null || !vehicles.Any())
            {
                return NotFound("No vehicles found with the given search criteria.");
            }

            return Ok(vehicles); // Devolver los vehículos filtrados
        }
    }
}


