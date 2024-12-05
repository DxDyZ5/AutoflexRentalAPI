using Microsoft.AspNetCore.Mvc;
using autoFlexrentalBackend.DTO;  // Si tienes el DTO
using autoFlexrentalBackend.Models;  // Si necesitas el modelo Vehicle
using autoFlexrentalBackend.Interfaces;  // Aseg�rate de tener la interfaz de tu servicio

namespace autoFlexrentalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IAutoflexRentalService _service; // Inyectamos el servicio

        public VehicleController(IAutoflexRentalService service)
        {
            _service = service;
        }

        // M�todo para obtener todos los veh�culos
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _service.GetAllVehicles();  // Llamamos al servicio
            return Ok(vehicles);
        }

        // POST: api/vehicles
        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.AddVehicle(vehicleDto);  // Llamamos al servicio para agregar el veh�culo
                return CreatedAtAction(nameof(GetAllVehicles), new { id = vehicleDto.VehicleId }, vehicleDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al agregar el veh�culo: {ex.Message}");
            }
        }

        // PUT: api/vehicles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.UpdateVehicle(vehicleDto);  // Llamamos al servicio para actualizar el veh�culo
                return Ok(vehicleDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el veh�culo: {ex.Message}");
            }
        }

        // DELETE: api/vehicles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            try
            {
                await _service.DeleteVehicle(id);  // Llamamos al servicio para eliminar el veh�culo
                return NoContent();  // 204 No Content: Eliminaci�n exitosa sin cuerpo
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);  // 404 Not Found si el veh�culo no existe
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el veh�culo: {ex.Message}");  // 400 BadRequest en caso de otros errores
            }
        }
    }
}
