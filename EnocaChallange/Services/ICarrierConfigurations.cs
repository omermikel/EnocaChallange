using EnocaChallange.Models;

namespace EnocaChallange.Services
{
    public interface ICarrierConfigurationService
    {
        Task<IEnumerable<CarrierConfiguration>> GetAllCarrierConfigurationsAsync();
        Task<CarrierConfiguration> GetCarrierConfigurationByIdAsync(int id);
        Task AddCarrierConfigurationAsync(CarrierConfiguration configuration);
        Task UpdateCarrierConfigurationAsync(CarrierConfiguration configuration);
        Task DeleteCarrierConfigurationAsync(int id);
    }
}
