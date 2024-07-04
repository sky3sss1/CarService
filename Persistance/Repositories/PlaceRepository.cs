namespace Persistance.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly ApplicationDbContext _context;

        public PlaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async public Task<Place> Add(Place place)
        {
            _context.Places.Add(place);
            await _context.SaveChangesAsync();
            return place;
        }

        public async Task<Place> Delete(Place place)
        {
            var placeToDelete = await _context.Places.FirstOrDefaultAsync(c => c.Id == place.Id);
            if (placeToDelete != null)
            {
                _context.Places.Remove(placeToDelete);
                await _context.SaveChangesAsync();
                return placeToDelete;
            }
            return null;
        }
        public async Task<Place> GetById(Guid id) => await _context.Places.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Place> Update(Place place)
        {
            _context.Places.Update(place);
            await _context.SaveChangesAsync();
            return place;
        }
        public async Task<IEnumerable<Place>> GetAll()
        {
            return await _context.Places.ToListAsync();
        }
    }
}
