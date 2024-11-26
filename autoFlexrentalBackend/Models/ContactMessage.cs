using System;
using System.Collections.Generic;

namespace autoFlexrentalBackend.Models;

public partial class ContactMessage
{
    public int MessageId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Message { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
