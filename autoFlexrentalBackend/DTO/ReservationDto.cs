using System.ComponentModel.DataAnnotations;

namespace autoFlexrentalBackend.DTO
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Vehicle ID is required")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total Price must be a positive number")]
        public decimal TotalPrice { get; set; }

        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
