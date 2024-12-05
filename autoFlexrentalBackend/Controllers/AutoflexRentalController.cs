using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace autoFlexrentalBackend.Controllers
{
    [ApiController]
    [Route("api/CRUD")]
    public class AutoflexRentalController : ControllerBase
    {
        private readonly IAutoflexRentalService _service;

        public AutoflexRentalController(IAutoflexRentalService service)
        {
            _service = service;
        }

        // Usuarios
        [HttpGet("users")]
        public IActionResult GetUserList()
        {
            return Ok(_service.GetAllUsers());
        }

        [HttpGet("users/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _service.GetUserById(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("users")]
        public IActionResult AddUser([FromBody] UserDto user)
        {
            _service.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("users/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto user)
        {
            if (_service.GetUserById(id) == null)
                return NotFound();

            user.UserId = id;
            _service.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _service.GetUserById(id);
            if (user == null)
                return NotFound();

            _service.DeleteUser(user);
            return NoContent();
        }

        [HttpGet("vehicles")]
        public async Task<IActionResult> GetVehicleList()
        {
            try
            {
                var vehicles = await _service.GetAllVehicles();  // Esperamos que la tarea se complete
                return Ok(vehicles);  // Regresamos el resultado de la tarea (no la tarea misma)
            }
            catch (Exception ex)
            {
                // Manejo de errores, si es necesario
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("vehicles/{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = _service.GetVehicleById(id);
            return vehicle == null ? NotFound() : Ok(vehicle);
        }

        [HttpPost("vehicles")]
        public IActionResult AddVehicle([FromBody] VehicleDto vehicle)
        {
            _service.AddVehicle(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.VehicleId }, vehicle);
        }

        [HttpPut("vehicles/{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody] VehicleDto vehicle)
        {
            if (_service.GetVehicleById(id) == null)
                return NotFound();

            vehicle.VehicleId = id;
            _service.UpdateVehicle(vehicle);
            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            try
            {
                // Pasa el ID (int) en lugar del objeto completo VehicleDto
                await _service.DeleteVehicle(id);
                return NoContent();  // 204 No Content: Eliminación exitosa sin cuerpo
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);  // 404 Not Found si el vehículo no existe
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el vehículo: {ex.Message}");  // 400 BadRequest en caso de otros errores
            }
        }

        // Reservas
        [HttpGet("reservations")]
        public IActionResult GetReservationList()
        {
            return Ok(_service.GetAllReservations());
        }

        [HttpGet("reservations/{id}")]
        public IActionResult GetReservationById(int id)
        {
            var reservation = _service.GetReservationById(id);
            return reservation == null ? NotFound() : Ok(reservation);
        }

        [HttpPost("reservations")]
        public IActionResult AddReservation([FromBody] ReservationDto reservation)
        {
            _service.AddReservation(reservation);
            _service.NotifyUser(reservation.UserId, "Reservation created successfully.", "Reservation Created");
            return CreatedAtAction(nameof(GetReservationById), new { id = reservation.ReservationId }, reservation);
        }

        [HttpPut("reservations/{id}")]
        public IActionResult UpdateReservation(int id, [FromBody] ReservationDto reservation)
        {
            if (_service.GetReservationById(id) == null)
                return NotFound();

            reservation.ReservationId = id;
            _service.UpdateReservation(reservation);
            _service.NotifyUser(reservation.UserId, "Reservation updated successfully.", "Reservation Updated");
            return Ok(reservation);
        }

        [HttpDelete("reservations/{id}")]
        public IActionResult CancelReservation(int id)
        {
            var reservation = _service.GetReservationById(id);
            if (reservation == null)
                return NotFound();

            _service.CancelReservation(id);
            _service.NotifyUser(reservation.UserId, "Reservation cancelled successfully.", "Reservation Cancelled");
            return NoContent();
        }

        // Mensajes de contacto
        [HttpGet("contactMessages")]
        public IActionResult GetContactMessageList()
        {
            return Ok(_service.GetAllContactMessages());
        }

        [HttpGet("contactMessages/{id}")]
        public IActionResult GetContactMessageById(int id)
        {
            var message = _service.GetContactMessageById(id);
            return message == null ? NotFound() : Ok(message);
        }

        [HttpPost("contactMessages")]
        public IActionResult AddContactMessage([FromBody] ContactMessageDto message)
        {
            _service.AddContactMessage(message);
            return CreatedAtAction(nameof(GetContactMessageById), new { id = message.MessageId }, message);
        }

        [HttpPut("contactMessages/{id}")]
        public IActionResult UpdateContactMessage(int id, [FromBody] ContactMessageDto message)
        {
            if (_service.GetContactMessageById(id) == null)
                return NotFound();

            message.MessageId = id;
            _service.UpdateContactMessage(message);
            return Ok(message);
        }

        [HttpDelete("contactMessages/{id}")]
        public IActionResult DeleteContactMessage(int id)
        {
            var message = _service.GetContactMessageById(id);
            if (message == null)
                return NotFound();

            _service.DeleteContactMessage(message);
            return NoContent();
        }

        // Why Choose Us
        [HttpGet("whyChooseUs")]
        public IActionResult GetWhyChooseUsList()
        {
            return Ok(_service.GetAllWhyChooseUsItems());
        }

        [HttpGet("whyChooseUs/{id}")]
        public IActionResult GetWhyChooseUsById(int id)
        {
            var item = _service.GetWhyChooseUsById(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost("whyChooseUs")]
        public IActionResult AddWhyChooseUs([FromBody] WhyChooseUsDto item)
        {
            var createdItem = _service.AddWhyChooseUsItem(item);
            return CreatedAtAction(nameof(GetWhyChooseUsById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("whyChooseUs/{id}")]
        public IActionResult UpdateWhyChooseUs(int id, [FromBody] WhyChooseUsDto item)
        {
            if (_service.GetWhyChooseUsById(id) == null)
                return NotFound();

            item.Id = id;
            _service.UpdateWhyChooseUsItem(item);
            return Ok(item);
        }

        [HttpDelete("whyChooseUs/{id}")]
        public IActionResult DeleteWhyChooseUs(int id)
        {
            if (_service.GetWhyChooseUsById(id) == null)
                return NotFound();

            _service.DeleteWhyChooseUsItem(id);
            return NoContent();
        }
    }
}
