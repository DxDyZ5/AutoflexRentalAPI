using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Interfaces;
using autoFlexrentalBackend.Models;

namespace autoFlexrentalBackend.Services
{
    public class AutoflexRentalService : IAutoflexRentalService
    {
        private readonly AutoFlexRentalContext _context;

        public AutoflexRentalService(AutoFlexRentalContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _context.Users.Select(u => new UserDto
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                PasswordHash = u.PasswordHash,
                Role = u.Role,
                CreatedAt = u.CreatedAt
            });
        }

        public UserDto GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }

        public void AddUser(UserDto user)
        {
            _context.Users.Add(new User
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                Role = user.Role,
                CreatedAt = DateTime.Now
            });
            _context.SaveChanges();
        }

        public void UpdateUser(UserDto user)
        {
            var existingUser = _context.Users.Find(user.UserId);
            if (existingUser == null) return;

            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Role = user.Role;
            _context.SaveChanges();
        }

        public void DeleteUser(UserDto user)
        {
            var existingUser = _context.Users.Find(user.UserId);
            if (existingUser == null) return;

            _context.Users.Remove(existingUser);
            _context.SaveChanges();
        }

        // VEHICLES
        public IEnumerable<VehicleDto> GetAllVehicles()
        {
            return _context.Vehicles.Select(v => new VehicleDto
            {
                VehicleId = v.VehicleId,
                Brand = v.Brand,
                Model = v.Model,
                DailyPrice = v.DailyPrice,
                Availability = v.Availability,
                ImageUrl = v.ImageUrl,
                CreatedAt = v.CreatedAt
            });
        }

        public VehicleDto GetVehicleById(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null) return null;

            return new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                DailyPrice = vehicle.DailyPrice,
                Availability = vehicle.Availability,
                ImageUrl = vehicle.ImageUrl,
                CreatedAt = vehicle.CreatedAt
            };
        }

        public void AddVehicle(VehicleDto vehicle)
        {
            _context.Vehicles.Add(new Vehicle
            {
                VehicleId = vehicle.VehicleId,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                DailyPrice = vehicle.DailyPrice,
                Availability = vehicle.Availability,
                ImageUrl = vehicle.ImageUrl,
                CreatedAt = DateTime.Now
            });
            _context.SaveChanges();
        }

        public void UpdateVehicle(VehicleDto vehicle)
        {
            var existingVehicle = _context.Vehicles.Find(vehicle.VehicleId);
            if (existingVehicle == null) return;

            existingVehicle.Brand = vehicle.Brand;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.DailyPrice = vehicle.DailyPrice;
            existingVehicle.Availability = vehicle.Availability;
            existingVehicle.ImageUrl = vehicle.ImageUrl;
            _context.SaveChanges();
        }

        public void DeleteVehicle(VehicleDto vehicle)
        {
            var existingVehicle = _context.Vehicles.Find(vehicle.VehicleId);
            if (existingVehicle == null) return;

            _context.Vehicles.Remove(existingVehicle);
            _context.SaveChanges();
        }

        // RESERVATIONS
        public IEnumerable<ReservationDto> GetAllReservations()
        {
            return _context.Reservations.Select(r => new ReservationDto
            {
                ReservationId = r.ReservationId,
                UserId = r.UserId,
                VehicleId = r.VehicleId,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                TotalPrice = r.TotalPrice,
                Status = r.Status,
                CreatedAt = r.CreatedAt
            });
        }

        public ReservationDto GetReservationById(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation == null) return null;

            return new ReservationDto
            {
                ReservationId = reservation.ReservationId,
                UserId = reservation.UserId,
                VehicleId = reservation.VehicleId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                TotalPrice = reservation.TotalPrice,
                Status = reservation.Status,
                CreatedAt = reservation.CreatedAt
            };
        }

        public void AddReservation(ReservationDto reservation)
        {
            _context.Reservations.Add(new Reservation
            {
                ReservationId = reservation.ReservationId,
                UserId = reservation.UserId,
                VehicleId = reservation.VehicleId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                TotalPrice = reservation.TotalPrice,
                Status = reservation.Status,
                CreatedAt = DateTime.Now
            });
            _context.SaveChanges();
        }

        public void UpdateReservation(ReservationDto reservation)
        {
            var existingReservation = _context.Reservations.Find(reservation.ReservationId);
            if (existingReservation == null) return;

            existingReservation.StartDate = reservation.StartDate;
            existingReservation.EndDate = reservation.EndDate;
            existingReservation.TotalPrice = reservation.TotalPrice;
            existingReservation.Status = reservation.Status;
            _context.SaveChanges();
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            var existingReservation = _context.Reservations.Find(reservation.ReservationId);
            if (existingReservation == null) return;

            _context.Reservations.Remove(existingReservation);
            _context.SaveChanges();
        }

        // CONTACT MESSAGES
        public IEnumerable<ContactMessageDto> GetAllContactMessages()
        {
            return _context.ContactMessages.Select(m => new ContactMessageDto
            {
                MessageId = m.MessageId,
                FullName = m.FullName,
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                Message = m.Message,
                Status = m.Status,
                CreatedAt = m.CreatedAt
            });
        }

        public ContactMessageDto GetContactMessageById(int id)
        {
            var message = _context.ContactMessages.Find(id);
            if (message == null) return null;

            return new ContactMessageDto
            {
                MessageId = message.MessageId,
                FullName = message.FullName,
                Email = message.Email,
                PhoneNumber = message.PhoneNumber,
                Message = message.Message,
                Status = message.Status,
                CreatedAt = message.CreatedAt
            };
        }

        public void AddContactMessage(ContactMessageDto message)
        {
            _context.ContactMessages.Add(new ContactMessage
            {
                MessageId = message.MessageId,
                FullName = message.FullName,
                Email = message.Email,
                PhoneNumber = message.PhoneNumber,
                Message = message.Message,
                Status = message.Status ?? "Unread",
                CreatedAt = DateTime.Now
            });
            _context.SaveChanges();
        }

        public void UpdateContactMessage(ContactMessageDto messageDto)
        {
            var message = _context.ContactMessages.FirstOrDefault(m => m.MessageId == messageDto.MessageId);
            if (message == null) return;

            message.Status = messageDto.Status ?? message.Status;
            message.Message = messageDto.Message ?? message.Message;

            _context.ContactMessages.Update(message);
            _context.SaveChanges();
        }

        public void DeleteContactMessage(ContactMessageDto messageDto)
        {
            var message = _context.ContactMessages.FirstOrDefault(m => m.MessageId == messageDto.MessageId);
            if (message == null) return;

            _context.ContactMessages.Remove(message);
            _context.SaveChanges();
        }
    }
}

