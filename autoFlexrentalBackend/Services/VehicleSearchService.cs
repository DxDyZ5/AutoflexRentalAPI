using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Interfaces;
using autoFlexrentalBackend.Models;
using System.Linq;

namespace autoFlexrentalBackend.Services
{
    public class VehicleSearchService : IVehicleSearchService
    {
        private readonly AutoFlexRentalContext _context;

        public VehicleSearchService(AutoFlexRentalContext context)
        {
            _context = context;
        }

        public IEnumerable<VehicleDto> SearchVehicles(string? brand = null, string? model = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var query = _context.Vehicles.AsQueryable();

            // Filtrar por marca
            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(v => v.Brand.Contains(brand));
            }

            // Filtrar por modelo
            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(v => v.Model.Contains(model));
            }

            // Filtrar por precio mínimo (DailyPrice)
            if (minPrice.HasValue)
            {
                query = query.Where(v => v.DailyPrice >= minPrice.Value);
            }

            // Filtrar por precio máximo (DailyPrice)
            if (maxPrice.HasValue)
            {
                query = query.Where(v => v.DailyPrice <= maxPrice.Value);
            }

            return query.Select(v => new VehicleDto
            {
                VehicleId = v.VehicleId,
                Brand = v.Brand,
                Model = v.Model,
                DailyPrice = v.DailyPrice,
                Availability = v.Availability.GetValueOrDefault(false),  // Default to false if Availability is null
                ImageUrl = v.ImageUrl,
            }).ToList();
        }
    }
}
