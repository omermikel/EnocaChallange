using EnocaChallange.Models;
using EnocaChallange.Repositories;

namespace EnocaChallange.Services
{
    public class CarrierConfigurationService : ICarrierConfigurationService
    {
        private readonly IRepository<CarrierConfiguration> _repository;

        public CarrierConfigurationService(IRepository<CarrierConfiguration> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CarrierConfiguration>> GetAllCarrierConfigurationsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CarrierConfiguration> GetCarrierConfigurationByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddCarrierConfigurationAsync(CarrierConfiguration configuration)
        {
            await _repository.AddAsync(configuration);
        }

        public async Task UpdateCarrierConfigurationAsync(CarrierConfiguration configuration)
        {
            await _repository.UpdateAsync(configuration);
        }

        public async Task DeleteCarrierConfigurationAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
