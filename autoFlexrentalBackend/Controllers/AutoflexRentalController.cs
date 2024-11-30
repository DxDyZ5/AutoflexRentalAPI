using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace autoFlexrentalBackend.Controllers
{
    [ApiController]
    [Route("api/CRUD")]
    public class AutoflexRentalController : Controller
    {
        private readonly IAutoflexRentalService _service;

        public AutoflexRentalController(IAutoflexRentalService service)
        {
            _service = service;
        }

        // Users
        [Authorize]
        [HttpGet("users")]
        public IActionResult GetUserList()
        {
            try
            {
                return Ok(_service.GetAllUsers());
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("users/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _service.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("users")]
        public IActionResult AddUser([FromBody] UserDto user)
        {
            try
            {
                _service.AddUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("users/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto user)
        {
            try
            {
                var existingUser = _service.GetUserById(id);
                if (existingUser == null)
                {
                    return NotFound();
                }
                user.UserId = id;
                _service.UpdateUser(user);
                return Ok(user);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _service.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                _service.DeleteUser(user);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        // Vehicles
        [Authorize]
        [HttpGet("vehicles")]
        public IActionResult GetVehicleList()
        {
            try
            {
                return Ok(_service.GetAllVehicles());
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("vehicles/{id}")]
        public IActionResult GetVehicleById(int id)
        {
            try
            {
                var vehicle = _service.GetVehicleById(id);
                if (vehicle == null)
                {
                    return NotFound();
                }
                return Ok(vehicle);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("vehicles")]
        public IActionResult AddVehicle([FromBody] VehicleDto vehicle)
        {
            try
            {
                _service.AddVehicle(vehicle);
                return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.VehicleId }, vehicle);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("vehicles/{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody] VehicleDto vehicle)
        {
            try
            {
                var existingVehicle = _service.GetVehicleById(id);
                if (existingVehicle == null)
                {
                    return NotFound();
                }
                vehicle.VehicleId = id;
                _service.UpdateVehicle(vehicle);
                return Ok(vehicle);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("vehicles/{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            try
            {
                var vehicle = _service.GetVehicleById(id);
                if (vehicle == null)
                {
                    return NotFound();
                }
                _service.DeleteVehicle(vehicle);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        // Reservations

        [Authorize]
        [HttpGet("reservations")]
        public IActionResult GetReservationList()
        {
            try
            {
                return Ok(_service.GetAllReservations());
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("reservations/{id}")]
        public IActionResult GetReservationById(int id)
        {
            try
            {
                var reservation = _service.GetReservationById(id);
                if (reservation == null)
                {
                    return NotFound();
                }
                return Ok(reservation);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin, Customer")]
        [HttpPost("reservations")]
        public IActionResult AddReservation([FromBody] ReservationDto reservation)
        {
            try
            {
                _service.AddReservation(reservation);
                return CreatedAtAction(nameof(GetReservationById), new { id = reservation.ReservationId }, reservation);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        
        [Authorize(Roles = "Admin, Customer")]
        [HttpPut("reservations/{id}")]
        public IActionResult UpdateReservation(int id, [FromBody] ReservationDto reservation)
        {
            try
            {
                var existingReservation = _service.GetReservationById(id);
                if (existingReservation == null)
                {
                    return NotFound();
                }
                reservation.ReservationId = id;
                _service.UpdateReservation(reservation);
                return Ok(reservation);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }


        [Authorize(Roles = "Admin, Customer")]
        [HttpDelete("reservations/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            try
            {
                var reservation = _service.GetReservationById(id);
                if (reservation == null)
                {
                    return NotFound();
                }
                _service.DeleteReservation(reservation);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        // Contact Messages
        [Authorize]
        [HttpGet("contactMessages")]
        public IActionResult GetContactMessageList()
        {
            try
            {
                return Ok(_service.GetAllContactMessages());
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("contactMessages/{id}")]
        public IActionResult GetContactMessageById(int id)
        {
            try
            {
                var message = _service.GetContactMessageById(id);
                if (message == null)
                {
                    return NotFound();
                }
                return Ok(message);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("contactMessages")]
        public IActionResult AddContactMessage([FromBody] ContactMessageDto message)
        {
            try
            {
                _service.AddContactMessage(message);
                return CreatedAtAction(nameof(GetContactMessageById), new { id = message.MessageId }, message);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("contactMessages/{id}")]
        public IActionResult UpdateContactMessage(int id, [FromBody] ContactMessageDto message)
        {
            try
            {
                var existingMessage = _service.GetContactMessageById(id);
                if (existingMessage == null)
                {
                    return NotFound();
                }
                message.MessageId = id;
                _service.UpdateContactMessage(message);
                return Ok(message);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("contactMessages/{id}")]
        public IActionResult DeleteContactMessage(int id)
        {
            try
            {
                var message = _service.GetContactMessageById(id);
                if (message == null)
                {
                    return NotFound();
                }
                _service.DeleteContactMessage(message);
                return NoContent();
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
        }

        // Why Choose Us
        [HttpGet("whyChooseUs")]
        public IActionResult GetWhyChooseUsList()
        {
            var items = _service.GetAllWhyChooseUsItems();
            return Ok(items);
        }

        [HttpGet("whyChooseUs/{id}")]
        public IActionResult GetWhyChooseUsById(int id)
        {
            var item = _service.GetWhyChooseUsById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("whyChooseUs")]
        public IActionResult AddWhyChooseUs([FromBody] WhyChooseUsDto itemDto)
        {
            var createdItem = _service.AddWhyChooseUsItem(itemDto);
            return CreatedAtAction(nameof(GetWhyChooseUsById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("whyChooseUs/{id}")]
        public IActionResult UpdateWhyChooseUs(int id, [FromBody] WhyChooseUsDto itemDto)
        {
            var existingItem = _service.GetWhyChooseUsById(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            itemDto.Id = id;
            _service.UpdateWhyChooseUsItem(itemDto);
            return Ok(itemDto);
        }

        [HttpDelete("whyChooseUs/{id}")]
        public IActionResult DeleteWhyChooseUs(int id)
        {
            var item = _service.GetWhyChooseUsById(id);
            if (item == null)
            {
                return NotFound();
            }

            _service.DeleteWhyChooseUsItem(id);
            return NoContent();
        }

    }
}
    