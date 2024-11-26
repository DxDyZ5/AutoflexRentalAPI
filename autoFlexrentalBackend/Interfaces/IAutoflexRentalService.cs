using autoFlexrentalBackend.DTO;

namespace autoFlexrentalBackend.Interfaces
{
    public interface IAutoflexRentalService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        void AddUser(UserDto user);
        void UpdateUser(UserDto user);
        void DeleteUser(UserDto user);

        IEnumerable<VehicleDto> GetAllVehicles();
        VehicleDto GetVehicleById(int id);
        void AddVehicle(VehicleDto vehicle);
        void UpdateVehicle(VehicleDto vehicle);
        void DeleteVehicle(VehicleDto vehicle);

        IEnumerable<ReservationDto> GetAllReservations();
        ReservationDto GetReservationById(int id);
        void AddReservation(ReservationDto reservation);
        void UpdateReservation(ReservationDto reservation);
        void DeleteReservation(ReservationDto reservation);

        IEnumerable<ContactMessageDto> GetAllContactMessages();
        ContactMessageDto GetContactMessageById(int id);
        void AddContactMessage(ContactMessageDto message);
        void UpdateContactMessage(ContactMessageDto message);
        void DeleteContactMessage(ContactMessageDto message);

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
    }
}
