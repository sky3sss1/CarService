namespace Persistance.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ApplicationDbContext _context;

        public ParkingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async public Task<Parking> Add(Parking parking)
        {
            _context.Parkings.Add(parking);
            await _context.SaveChangesAsync();
            return parking;
        }

        public async Task<Parking> Delete(Parking parking)
        {
            var parkingToDelete = await _context.Parkings.FirstOrDefaultAsync(c => c.Id == parking.Id);
            if (parkingToDelete != null)
            {
                _context.Parkings.Remove(parkingToDelete);
                await _context.SaveChangesAsync();
                return parkingToDelete;
            }
            return null;
        }
        public async Task<Parking> GetById(Guid id) => await _context.Parkings.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Parking> Update(Parking parking)
        {
            _context.Parkings.Update(parking);
            await _context.SaveChangesAsync();
            return parking;
        }
        public async Task<IEnumerable<Parking>> GetAll()
        {
            return await _context.Parkings.ToListAsync();
        }
    }
}
