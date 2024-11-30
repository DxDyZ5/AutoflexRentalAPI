using System.ComponentModel.DataAnnotations;

namespace autoFlexrentalBackend.DTO
{
    public class ContactMessageDto
    {
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }

        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
