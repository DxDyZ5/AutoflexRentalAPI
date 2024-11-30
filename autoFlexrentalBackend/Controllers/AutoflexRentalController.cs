using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("users")]
        public IActionResult GetUserList()
        {
            return Ok(_service.GetAllUsers());
        }

        [HttpGet("users/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _service.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
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
            var existingUser = _service.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            user.UserId = id;
            _service.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _service.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _service.DeleteUser(user);
            return NoContent();
        }

        // Vehicles
        [HttpGet("vehicles")]
        public IActionResult GetVehicleList()
        {
            return Ok(_service.GetAllVehicles());
        }

        [HttpGet("vehicles/{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = _service.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
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
            var existingVehicle = _service.GetVehicleById(id);
            if (existingVehicle == null)
            {
                return NotFound();
            }
            vehicle.VehicleId = id;
            _service.UpdateVehicle(vehicle);
            return Ok(vehicle);
        }

        [HttpDelete("vehicles/{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = _service.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _service.DeleteVehicle(vehicle);
            return NoContent();
        }

        // Reservations
        [HttpGet("reservations")]
        public IActionResult GetReservationList()
        {
            return Ok(_service.GetAllReservations());
        }

        [HttpGet("reservations/{id}")]
        public IActionResult GetReservationById(int id)
        {
            var reservation = _service.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost("reservations")]
        public IActionResult AddReservation([FromBody] ReservationDto reservation)
        {
            _service.AddReservation(reservation);
            return CreatedAtAction(nameof(GetReservationById), new { id = reservation.ReservationId }, reservation);
        }

        [HttpPut("reservations/{id}")]
        public IActionResult UpdateReservation(int id, [FromBody] ReservationDto reservation)
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

        [HttpDelete("reservations/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _service.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            _service.DeleteReservation(reservation);
            return NoContent();
        }

        // Contact Messages
        [HttpGet("contactMessages")]
        public IActionResult GetContactMessageList()
        {
            return Ok(_service.GetAllContactMessages());
        }

        [HttpGet("contactMessages/{id}")]
        public IActionResult GetContactMessageById(int id)
        {
            var message = _service.GetContactMessageById(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
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
            var existingMessage = _service.GetContactMessageById(id);
            if (existingMessage == null)
            {
                return NotFound();
            }
            message.MessageId = id;
            _service.UpdateContactMessage(message);
            return Ok(message);
        }

        [HttpDelete("contactMessages/{id}")]
        public IActionResult DeleteContactMessage(int id)
        {
            var message = _service.GetContactMessageById(id);
            if (message == null)
            {
                return NotFound();
            }
            _service.DeleteContactMessage(message);
            return NoContent();
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
    