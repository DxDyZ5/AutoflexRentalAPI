namespace autoFlexrentalBackend.DTO
{
    public class ContactMessageDto
    {
        public int MessageId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public string Status { get; set; } // 'Unread', 'Read'
        public DateTime? CreatedAt { get; set; }
    }
}
