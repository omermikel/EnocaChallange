using EnocaChallange.Models;

namespace EnocaChallange.Services
{
    public interface ICarrierService
    {
        Task<IEnumerable<Carrier>> GetAllCarriersAsync();
        Task AddCarrierAsync(Carrier carrier);
        Task UpdateCarrierAsync(Carrier carrier);
        Task DeleteCarrierAsync(int id);
    }
}
