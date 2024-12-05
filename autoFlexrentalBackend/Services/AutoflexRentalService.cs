using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Interfaces;
using autoFlexrentalBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace autoFlexrentalBackend.Services
{
    public class AutoflexRentalService : IAutoflexRentalService
    {
        private readonly AutoFlexRentalContext _context;

        public AutoflexRentalService(AutoFlexRentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    FullName = u.FullName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    PasswordHash = u.PasswordHash,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt ?? DateTime.MinValue // Handle nullable DateTime
                }).ToListAsync();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                Role = user.Role,
                CreatedAt = user.CreatedAt ?? DateTime.MinValue // Handle nullable DateTime
            };
        }

        public async Task AddUser(UserDto user)
        {
            var newUser = new User
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                Role = user.Role,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(UserDto user)
        {
            var existingUser = await _context.Users.FindAsync(user.UserId);
            if (existingUser == null) return;

            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Role = user.Role;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var existingUser = await _context.Users.FindAsync(userId);
            if (existingUser == null) return;

            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();
        }

        // VEHICLES

        public async Task<IEnumerable<VehicleDto>> GetAllVehicles()
        {
            try
            {
                // Recupera todos los vehículos desde la base de datos
                var vehicles = await _context.Vehicles
                    .Include(v => v.Category)  // Incluir la categoría si es necesario
                    .ToListAsync();

                // Mapea las entidades Vehicle a DTOs (VehicleDto)
                var vehicleDtos = vehicles.Select(v => new VehicleDto
                {
                    VehicleId = v.VehicleId,
                    Brand = v.Brand,
                    Model = v.Model,
                    DailyPrice = v.DailyPrice,
                    Availability = v.Availability ?? false,  // Asegúrate de que Availability no sea nullable si no lo necesitas
                    ImageUrl = v.ImageUrl,
                    Year = v.Year ?? 0,  // Si Year es nullable, convierte a 0 si es null
                    Color = v.Color,
                    CategoryName = v.Category?.Name  // Asumiendo que tienes una relación Category con su propiedad Name
                }).ToList();

                return vehicleDtos;  // Devuelve la lista de DTOs
            }
            catch (Exception ex)
            {
                // Maneja cualquier error que ocurra durante la recuperación de vehículos
                throw new InvalidOperationException("Error al recuperar vehículos.", ex);
            }
        }




        public async Task<VehicleDto> GetVehicleById(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return null;

            return new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                DailyPrice = vehicle.DailyPrice,
                Availability = vehicle.Availability.GetValueOrDefault(false), // Si Availability es null, asignamos false
                ImageUrl = vehicle.ImageUrl ?? string.Empty, // Aseguramos que ImageUrl nunca sea null
                Year = vehicle.Year ?? 0, // Asignamos 0 si Year es null
                Color = vehicle.Color ?? string.Empty, // Asignamos un string vacío si Color es null
                CategoryName = vehicle.Category?.Name ?? string.Empty, // Usamos el operador null-conditional para evitar errores si Category es null
            };
        }


        public async Task AddVehicle(VehicleDto vehicleDto)
        {
            var category = await _context.Category
                .FirstOrDefaultAsync(c => c.Name.Equals(vehicleDto.CategoryName, StringComparison.OrdinalIgnoreCase));

            if (category == null)
            {
                throw new InvalidOperationException($"Category '{vehicleDto.CategoryName}' not found.");
            }

            var vehicle = new Vehicle
            {
                Brand = vehicleDto.Brand,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                Color = vehicleDto.Color ?? string.Empty,
                ImageUrl = vehicleDto.ImageUrl,
                Category = category,
                DailyPrice = vehicleDto.DailyPrice
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicle(VehicleDto vehicleDto)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleDto.VehicleId);
            if (vehicle == null)
            {
                throw new InvalidOperationException("Vehicle not found.");
            }

            vehicle.Brand = vehicleDto.Brand;
            vehicle.Model = vehicleDto.Model;
            vehicle.Year = vehicleDto.Year;
            vehicle.Color = vehicleDto.Color ?? string.Empty;
            vehicle.ImageUrl = vehicleDto.ImageUrl;

            var category = await _context.Category
                .FirstOrDefaultAsync(c => c.Name.Equals(vehicleDto.CategoryName, StringComparison.OrdinalIgnoreCase));

            if (category == null)
            {
                throw new InvalidOperationException($"Category '{vehicleDto.CategoryName}' not found.");
            }

            vehicle.Category = category;
            vehicle.DailyPrice = vehicleDto.DailyPrice;

            await _context.SaveChangesAsync();
        }

        // Eliminar un vehículo por ID
        [HttpDelete("{id}")]
        public async Task DeleteVehicle(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null)
            {
                throw new InvalidOperationException("Vehicle not found.");
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }





        // RESERVATIONS

        public async Task AddReservation(ReservationDto reservationDto)
        {
            if (!await IsVehicleAvailable(reservationDto.VehicleId, reservationDto.StartDate, reservationDto.EndDate))
            {
                throw new Exception("The selected vehicle is not available for the chosen dates.");
            }

            var reservation = new Reservation
            {
                UserId = reservationDto.UserId,
                VehicleId = reservationDto.VehicleId,
                StartDate = reservationDto.StartDate,
                EndDate = reservationDto.EndDate,
                TotalPrice = reservationDto.TotalPrice,
                Status = reservationDto.Status,
                Extras = reservationDto.Extras,
                CreatedAt = DateTime.Now
            };

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();

            await NotifyUser(reservation.UserId, "Reservation created successfully.", "Reservation Created");
        }

        public async Task UpdateReservation(ReservationDto reservationDto)
        {
            var reservation = await _context.Reservations.FindAsync(reservationDto.ReservationId);
            if (reservation == null)
            {
                throw new Exception("Reservation not found.");
            }

            reservation.StartDate = reservationDto.StartDate;
            reservation.EndDate = reservationDto.EndDate;
            reservation.TotalPrice = reservationDto.TotalPrice;
            reservation.Status = reservationDto.Status;
            reservation.Extras = reservationDto.Extras;

            await _context.SaveChangesAsync();
        }

        public async Task CancelReservation(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null)
            {
                throw new Exception("Reservation not found.");
            }

            reservation.Status = "Cancelled";
            await _context.SaveChangesAsync();

            await NotifyUser(reservation.UserId, "Your reservation has been cancelled.", "Reservation Cancelled");
        }

        public async Task NotifyUser(int userId, string content, string type)
        {
            var notification = new Notification
            {
                UserId = userId,
                Content = content,
                IsRead = false,
                CreatedAt = DateTime.Now
            };
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> IsVehicleAvailable(int vehicleId, DateTime startDate, DateTime endDate)
        {
            var overlappingReservations = await _context.Reservations
                .Where(r => r.VehicleId == vehicleId &&
                            r.Status != "Cancelled" &&
                            ((r.StartDate <= endDate && r.StartDate >= startDate) ||
                             (r.EndDate >= startDate && r.EndDate <= endDate)))
                .ToListAsync();

            return !overlappingReservations.Any();
        }

        // CONTACT MESSAGES
        public async Task<IEnumerable<ContactMessageDto>> GetAllContactMessages()
        {
            return await _context.ContactMessages.Select(m => new ContactMessageDto
            {
                MessageId = m.MessageId,
                FullName = m.FullName,
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                Message = m.Message,
                Status = m.Status,
                CreatedAt = m.CreatedAt
            }).ToListAsync();
        }

        public async Task<ContactMessageDto> GetContactMessageById(int id)
        {
            var message = await _context.ContactMessages.FindAsync(id);
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

        public async Task AddContactMessage(ContactMessageDto message)
        {
            var contactMessage = new ContactMessage
            {
                FullName = message.FullName,
                Email = message.Email,
                PhoneNumber = message.PhoneNumber,
                Message = message.Message,
                Status = message.Status ?? "Unread",
                CreatedAt = DateTime.Now
            };

            await _context.ContactMessages.AddAsync(contactMessage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContactMessage(ContactMessageDto messageDto)
        {
            var message = await _context.ContactMessages.FirstOrDefaultAsync(m => m.MessageId == messageDto.MessageId);
            if (message == null) return;

            message.Status = messageDto.Status ?? message.Status;
            message.Message = messageDto.Message ?? message.Message;

            _context.ContactMessages.Update(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactMessage(ContactMessageDto messageDto)
        {
            var message = await _context.ContactMessages.FirstOrDefaultAsync(m => m.MessageId == messageDto.MessageId);
            if (message == null) return;

            _context.ContactMessages.Remove(message);
            await _context.SaveChangesAsync();
        }

        // WHY CHOOSE US
        public IEnumerable<WhyChooseUsDto> GetAllWhyChooseUsItems()
        {
            return _context.WhyChooseUsItems.Select(item => new WhyChooseUsDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            }).ToList();
        }


        public WhyChooseUsDto GetWhyChooseUsById(int id)
        {
            var item = _context.WhyChooseUsItems.Find(id);
            if (item == null) return null;

            return new WhyChooseUsDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            };
        }


        public WhyChooseUsDto AddWhyChooseUsItem(WhyChooseUsDto itemDto)
        {
            var newItem = new WhyChooseUs
            {
                Title = itemDto.Title,
                Description = itemDto.Description
            };

            _context.WhyChooseUsItems.Add(newItem);
            _context.SaveChanges();

            return new WhyChooseUsDto
            {
                Id = newItem.Id,
                Title = newItem.Title,
                Description = newItem.Description
            };
        }


        public void UpdateWhyChooseUsItem(WhyChooseUsDto itemDto)
        {
            var item = _context.WhyChooseUsItems.Find(itemDto.Id);
            if (item != null)
            {
                item.Title = itemDto.Title;
                item.Description = itemDto.Description;
               

                _context.SaveChanges();
            }
        }

        public void DeleteWhyChooseUsItem(int id)
        {
            var item = _context.WhyChooseUsItems.Find(id);
            if (item != null)
            {
                _context.WhyChooseUsItems.Remove(item);
                _context.SaveChanges();
            }
        }

        IEnumerable<UserDto> IAutoflexRentalService.GetAllUsers()
        {
            throw new NotImplementedException();
        }

        UserDto IAutoflexRentalService.GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        void IAutoflexRentalService.AddUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        void IAutoflexRentalService.UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        VehicleDto IAutoflexRentalService.GetVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        
        

       

        public IEnumerable<ReservationDto> GetAllReservations()
        {
            throw new NotImplementedException();
        }

        public ReservationDto GetReservationById(int id)
        {
            throw new NotImplementedException();
        }

        void IAutoflexRentalService.AddReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        void IAutoflexRentalService.UpdateReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        void IAutoflexRentalService.CancelReservation(int reservationId)
        {
            throw new NotImplementedException();
        }

        void IAutoflexRentalService.NotifyUser(int userId, string content, string type)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ContactMessageDto> IAutoflexRentalService.GetAllContactMessages()
        {
            throw new NotImplementedException();
        }

        ContactMessageDto IAutoflexRentalService.GetContactMessageById(int id)
        {
            throw new NotImplementedException();
        }

        void IAutoflexRentalService.AddContactMessage(ContactMessageDto message)
        {
            throw new NotImplementedException();
        }

        void IAutoflexRentalService.UpdateContactMessage(ContactMessageDto message)
        {
            throw new NotImplementedException();
        }

        void IAutoflexRentalService.DeleteContactMessage(ContactMessageDto message)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(VehicleDto vehicle)
        {
            throw new NotImplementedException();
        }
    }
}

