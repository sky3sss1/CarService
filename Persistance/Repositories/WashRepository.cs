using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class WashRepository : IWashRepository
    {
        private readonly ApplicationDbContext _context;

        public WashRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async public Task<Wash> Add(Wash wash)
        {
            _context.Washes.Add(wash);
            await _context.SaveChangesAsync();
            return wash;
        }

        public async Task<Wash> Delete(Wash wash)
        {
            var washToDelete = await _context.Washes.FirstOrDefaultAsync(c => c.Id == wash.Id);
            if (washToDelete != null)
            {
                _context.Washes.Remove(washToDelete);
                await _context.SaveChangesAsync();
                return washToDelete;
            }
            return null;
        }
        public async Task<Wash> GetById(Guid id) => await _context.Washes.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Wash> Update(Wash wash)
        {
            _context.Washes.Update(wash);
            await _context.SaveChangesAsync();
            return wash;
        }
        public async Task<IEnumerable<Wash>> GetAll()
        {
            return await _context.Washes.ToListAsync();
        }
    }
}
