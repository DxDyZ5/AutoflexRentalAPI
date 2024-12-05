using System.Text.Json.Serialization;

namespace autoFlexrentalBackend.DTO
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal DailyPrice { get; set; }
        public bool Availability { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        [JsonIgnore]  // Ignora la propiedad en la serialización
        public string InternalProperty { get; set; }

        public string CategoryName { get; set; }
    }

}
