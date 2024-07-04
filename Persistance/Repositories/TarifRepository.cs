namespace Persistance.Repositories
{
    public class TarifRepository : ITarifRepository
    {
        private readonly ApplicationDbContext _context;

        public TarifRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async public Task<Tarif> Add(Tarif tarif)
        {
            _context.Tarifs.Add(tarif);
            await _context.SaveChangesAsync();
            return tarif;
        }

        public async Task<Tarif> Delete(Tarif tarif)
        {
            var tarifToDelete = await _context.Tarifs.FirstOrDefaultAsync(c => c.Id == tarif.Id);
            if (tarifToDelete != null)
            {
                _context.Tarifs.Remove(tarifToDelete);
                await _context.SaveChangesAsync();
                return tarifToDelete;
            }
            return null;
        }
        public async Task<Tarif> GetById(Guid id) => await _context.Tarifs.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Tarif> Update(Tarif tarif)
        {
            _context.Tarifs.Update(tarif);
            await _context.SaveChangesAsync();
            return tarif;
        }
        public async Task<IEnumerable<Tarif>> GetAll()
        {
            return await _context.Tarifs.ToListAsync();
        }
    }
}
