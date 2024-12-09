using EnocaChallange.Data;
using EnocaChallange.Models;
using Microsoft.EntityFrameworkCore;

namespace EnocaChallange.Repositories
{
    public class CarrierConfigurationRepository : IRepository<CarrierConfiguration>
    {
        private readonly AppDbContext _context;

        public CarrierConfigurationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarrierConfiguration>> GetAllAsync()
        {
            return await _context.CarrierConfigurations.ToListAsync();
        }

        public async Task<CarrierConfiguration> GetByIdAsync(int id)
        {
            return await _context.CarrierConfigurations.FindAsync(id);
        }

        public async Task AddAsync(CarrierConfiguration entity)
        {
            await _context.CarrierConfigurations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CarrierConfiguration entity)
        {
            _context.CarrierConfigurations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.CarrierConfigurations.FindAsync(id);
            if (entity != null)
            {
                _context.CarrierConfigurations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
