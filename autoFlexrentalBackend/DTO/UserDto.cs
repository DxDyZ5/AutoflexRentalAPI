using System.ComponentModel.DataAnnotations;

namespace autoFlexrentalBackend.DTO
{
    /// <summary>
    /// USER DTO PARA MANEJAR LA LOGICA
    /// </summary>
    public class UserDto
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
