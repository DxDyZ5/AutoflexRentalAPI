using autoFlexrentalBackend.DTO;

namespace autoFlexrentalBackend.Interfaces
{
    public interface IUserService
    {
        UserDto Authenticate(string email, string password);
        string GenerateJwt(UserDto user);
    }
}
