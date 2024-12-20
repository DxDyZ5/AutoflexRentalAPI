﻿namespace autoFlexrentalBackend.DTO
{
    public class ReservationDto
    {
        public int ReservationId { get; set; } 
        public int UserId { get; set; }        
        public int VehicleId { get; set; }     
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }   
        public decimal TotalPrice { get; set; } 
        public string Status { get; set; }      
        public string Extras { get; set; }     
        public DateTime CreatedAt { get; set; } 
    }
}
