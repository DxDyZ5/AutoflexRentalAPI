using autoFlexrentalBackend.DTO;

namespace autoFlexrentalBackend.Interfaces
{
    public interface IAutoflexRentalService
    {
        //USER
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        void AddUser(UserDto user);
        void UpdateUser(UserDto user);
        void DeleteUser(UserDto user);

        //VEHICLE
        IEnumerable<VehicleDto> GetAllVehicles();
        VehicleDto GetVehicleById(int id);
        void AddVehicle(VehicleDto vehicle);
        void UpdateVehicle(VehicleDto vehicle);
        void DeleteVehicle(VehicleDto vehicle);

        //RESERVATION
        IEnumerable<ReservationDto> GetAllReservations();
        ReservationDto GetReservationById(int id);
        void AddReservation(ReservationDto reservation);
        void UpdateReservation(ReservationDto reservation);
        void DeleteReservation(ReservationDto reservation);

        //CONTACT MESSAGE
        IEnumerable<ContactMessageDto> GetAllContactMessages();
        ContactMessageDto GetContactMessageById(int id);
        void AddContactMessage(ContactMessageDto message);
        void UpdateContactMessage(ContactMessageDto message);
        void DeleteContactMessage(ContactMessageDto message);

        //WHY CHOOSE US
        IEnumerable<WhyChooseUsDto> GetAllWhyChooseUsItems();
        WhyChooseUsDto GetWhyChooseUsById(int id);
        WhyChooseUsDto AddWhyChooseUsItem(WhyChooseUsDto itemDto);
        void UpdateWhyChooseUsItem(WhyChooseUsDto itemDto);
        void DeleteWhyChooseUsItem(int id);

    }
}
