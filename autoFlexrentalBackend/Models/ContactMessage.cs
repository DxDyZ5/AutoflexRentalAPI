using System;

namespace autoFlexrentalBackend.Models
{
    public partial class ContactMessage
    {
        public int MessageId { get; set; }  // Esta será la clave primaria
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }  // Asumo que es un campo de tipo datetime
    }
}
