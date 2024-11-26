using System;
using System.Collections.Generic;

namespace autoFlexrentalBackend.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public decimal DailyPrice { get; set; }

    public bool? Availability { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
