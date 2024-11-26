using autoFlexrentalBackend.DTO;

namespace autoFlexrentalBackend.Interfaces
{
    public interface IVehicleSearchService
    {
        IEnumerable<VehicleDto> SearchVehicles(string? brand = null, string? model = null, decimal? minPrice = null, decimal? maxPrice = null);
    }
}
