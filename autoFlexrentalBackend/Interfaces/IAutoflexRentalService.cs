using autoFlexrentalBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;  // Importar para usar Task

namespace autoFlexrentalBackend.Interfaces
{
    public interface IAutoflexRentalService
    {
        // Usuarios
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        void AddUser(UserDto user);
        void UpdateUser(UserDto user);
        void DeleteUser(UserDto user);

        // Vehículos
        Task<IEnumerable<VehicleDto>> GetAllVehicles();  // Cambié a Task para el método asincrónico
        VehicleDto GetVehicleById(int id);
        Task AddVehicle(VehicleDto vehicle); // Cambiar a Task
        Task UpdateVehicle(VehicleDto vehicle); // Cambiar a Task
        Task DeleteVehicle(int vehicleId); // Cambiar a Task
        // Reservas
        IEnumerable<ReservationDto> GetAllReservations();
        ReservationDto GetReservationById(int id);
        void AddReservation(ReservationDto reservation);
        void UpdateReservation(ReservationDto reservation);
        void CancelReservation(int reservationId);
        void NotifyUser(int userId, string content, string type);

        // Mensajes de Contacto
        IEnumerable<ContactMessageDto> GetAllContactMessages();
        ContactMessageDto GetContactMessageById(int id);
        void AddContactMessage(ContactMessageDto message);
        void UpdateContactMessage(ContactMessageDto message);
        void DeleteContactMessage(ContactMessageDto message);

        // Why Choose Us
        IEnumerable<WhyChooseUsDto> GetAllWhyChooseUsItems();
        WhyChooseUsDto GetWhyChooseUsById(int id);
        WhyChooseUsDto AddWhyChooseUsItem(WhyChooseUsDto itemDto);
        void UpdateWhyChooseUsItem(WhyChooseUsDto itemDto);
        void DeleteWhyChooseUsItem(int id);
    }
}




// Estos seran agregados en un futuro

//IEnumerable<NotificationDto> GetAllNotifications();
//NotificationDto GetNotificationById(int id);
//void AddNotification(NotificationDto notification);
//void UpdateNotification(NotificationDto notification);
//void DeleteNotification(NotificationDto notification);

//IEnumerable<ActivityLogDto> GetAllActivityLogs();
//ActivityLogDto GetActivityLogById(int id);
//void AddActivityLog(ActivityLogDto log);
//void UpdateActivityLog(ActivityLogDto log);
//void DeleteActivityLog(ActivityLogDto log);

