namespace Persistance.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly ApplicationDbContext _context;

        public RentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async public Task<Rent> Add(Rent rent)
        {
            _context.Rents.Add(rent);
            await _context.SaveChangesAsync();
            return rent;
        }

        public async Task<Rent> Delete(Rent rent)
        {
            var rentToDelete = await _context.Rents.FirstOrDefaultAsync(c => c.Id == rent.Id);
            if (rentToDelete != null)
            {
                _context.Rents.Remove(rentToDelete);
                await _context.SaveChangesAsync();
                return rentToDelete;
            }
            return null;
        }
        public async Task<Rent> GetById(Guid id) => await _context.Rents.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Rent> Update(Rent rent)
        {
            _context.Rents.Update(rent);
            await _context.SaveChangesAsync();
            return rent;
        }
        public async Task<IEnumerable<Rent>> GetAll()
        {
            return await _context.Rents.ToListAsync();
        }
    }
}
