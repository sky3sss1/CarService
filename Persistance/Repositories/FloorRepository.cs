namespace Persistance.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private readonly ApplicationDbContext _context;

        public FloorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async public Task<Floor> Add(Floor floor)
        {
            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();
            return floor;
        }

        public async Task<Floor> Delete(Floor floor)
        {
            var floorToDelete = await _context.Floors.FirstOrDefaultAsync(c => c.Id == floor.Id);
            if (floorToDelete != null)
            {
                _context.Floors.Remove(floorToDelete);
                await _context.SaveChangesAsync();
                return floorToDelete;
            }
            return null;
        }
        public async Task<Floor> GetById(Guid id) => await _context.Floors.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Floor> Update(Floor floor)
        {
            _context.Floors.Update(floor);
            await _context.SaveChangesAsync();
            return floor;
        }
        public async Task<IEnumerable<Floor>> GetAll()
        {
            return await _context.Floors.ToListAsync();
        }
    }
}
