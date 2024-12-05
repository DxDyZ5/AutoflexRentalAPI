using System;
using System.Collections.Generic;

namespace autoFlexrentalBackend.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }  // Nullable int for Year (porque puede no estar disponible)
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        public bool? Availability { get; set; }  // Nullable bool for Availability (porque puede no estar disponible)
        public DateTime? CreatedAt { get; set; }  // Nullable DateTime for CreatedAt
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Ensure DailyPrice is added to the model as a decimal
        public decimal DailyPrice { get; set; }

        // Collection for reservations
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        // Map Category to CategoryName in DTO
        public string CategoryName => Category?.Name; // Asume que 'Category' tiene una propiedad 'Name'
    }
}
