using System.ComponentModel.DataAnnotations;

namespace autoFlexrentalBackend.DTO
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Daily Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal DailyPrice { get; set; }

        [Required(ErrorMessage = "Availability is required")]
        public bool? Availability { get; set; }

        public string ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
