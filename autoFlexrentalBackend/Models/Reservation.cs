using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace autoFlexrentalBackend.Models;

public class Reservation
{
    [Key]
    public int ReservationId { get; set; } // Identificador único de la reserva

    [ForeignKey("User")]
    public int UserId { get; set; } // Clave foránea al usuario
    public virtual User User { get; set; } // Propiedad de navegación hacia User

    [ForeignKey("Vehicle")]
    public int VehicleId { get; set; } // Clave foránea al vehículo
    public virtual Vehicle Vehicle { get; set; } // Propiedad de navegación hacia Vehicle

    [Required]
    public DateTime StartDate { get; set; } // Fecha de inicio de la reserva

    [Required]
    public DateTime EndDate { get; set; } // Fecha de fin de la reserva

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal TotalPrice { get; set; } // Precio total de la reserva

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = "Pending"; // Estado de la reserva

    [MaxLength(255)]
    public string Extras { get; set; } // Información adicional

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Fecha de creación
}
