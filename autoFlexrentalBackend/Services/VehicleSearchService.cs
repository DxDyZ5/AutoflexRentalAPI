using autoFlexrentalBackend.DTO;
using autoFlexrentalBackend.Interfaces;
using autoFlexrentalBackend.Models;

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

            // Filter by brand
            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(v => v.Brand.Contains(brand));
            }

            // Filter by model
            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(v => v.Model.Contains(model));
            }

            // Filter by minimum price (DailyPrice)
            if (minPrice.HasValue)
            {
                query = query.Where(v => v.DailyPrice >= minPrice.Value);
            }

            // Filter by maximum price  (DailyPrice)
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
                Availability = v.Availability,
                ImageUrl = v.ImageUrl,
                CreatedAt = v.CreatedAt
            }).ToList();
        }
    }
}   

