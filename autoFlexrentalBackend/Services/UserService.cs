using autoFlexrentalBackend.Custom;
using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Interfaces;
using autoFlexrentalBackend.Models;

namespace autoFlexrentalBackend.Services
{
    public class UserService : IUserService
    {
        private readonly AutoFlexRentalContext _context; 
        private readonly Utilities _utilities;


        public UserService(AutoFlexRentalContext context, Utilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        public UserDto Authenticate(string email, string password)
        {
            // Find user by email
            var user = _context.Users
                .FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return null; // User not found
            }


            // Verify hashed password using the encryptSHA256 method from Utilities
            var hashedPassword = _utilities.encryptSHA256(password);
            if (hashedPassword != user.PasswordHash)
            {
                    return null; // Password mismatch
            }

            // Map entity to DTO
            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }

        

        public string GenerateJwt(UserDto user)
        {
            // Map DTO to User model 
            var userModel = new User
            {
                UserId = user.UserId,
                Email = user.Email,
                Role = user.Role
            };

            // Use Utilities to generate JWT
            return _utilities.generateJWT(userModel);
        }
    }
}
