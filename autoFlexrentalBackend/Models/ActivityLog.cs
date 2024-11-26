﻿using System;
using System.Collections.Generic;

namespace autoFlexrentalBackend.Models;

public partial class ActivityLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public string Action { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public virtual User? User { get; set; }
}
