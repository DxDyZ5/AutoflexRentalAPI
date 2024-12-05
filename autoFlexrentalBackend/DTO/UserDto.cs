using System.ComponentModel.DataAnnotations;

namespace autoFlexrentalBackend.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }

        public int Year { get; set; }
        public string Color { get; set; }


        public DateTime? CreatedAt { get; set; }
    }
}
