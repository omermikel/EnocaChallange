using EnocaChallange.Data;
using EnocaChallange.Models;
using Microsoft.EntityFrameworkCore;

namespace EnocaChallange.Repositories
{
    public class CarrierRepository : IRepository<Carrier>
    {
        private readonly AppDbContext _context;

        public CarrierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Carrier>> GetAllAsync()
        {
            return await _context.Carriers.ToListAsync();
        }

        public async Task<Carrier> GetByIdAsync(int id)
        {
            return await _context.Carriers.FindAsync(id);
        }

        public async Task AddAsync(Carrier entity)
        {
            await _context.Carriers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Carrier entity)
        {
            _context.Carriers.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Carriers.FindAsync(id);
            if (entity != null)
            {
                _context.Carriers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
