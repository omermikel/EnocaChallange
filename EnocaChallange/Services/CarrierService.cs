using EnocaChallange.Models;
using EnocaChallange.Repositories;

namespace EnocaChallange.Services
{
    public class CarrierService : ICarrierService
    {
        private readonly IRepository<Carrier> _carrierRepository;

        public CarrierService(IRepository<Carrier> carrierRepository)
        {
            _carrierRepository = carrierRepository;
        }

        public async Task<IEnumerable<Carrier>> GetAllCarriersAsync()
        {
            return await _carrierRepository.GetAllAsync();
        }

        public async Task AddCarrierAsync(Carrier carrier)
        {
            await _carrierRepository.AddAsync(carrier);
        }

        public async Task UpdateCarrierAsync(Carrier carrier)
        {
            await _carrierRepository.UpdateAsync(carrier);
        }

        public async Task DeleteCarrierAsync(int id)
        {
            await _carrierRepository.DeleteAsync(id);
        }
    }
}
