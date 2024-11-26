namespace autoFlexrentalBackend.DTO
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal DailyPrice { get; set; }
        public bool? Availability { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
