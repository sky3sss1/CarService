namespace Persistance.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async public Task<Car> Add(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Delete(Car car)
        {
            var carToDelete = await _context.Cars.FirstOrDefaultAsync(c => c.Id == car.Id);
            if (carToDelete != null)
            {
                _context.Cars.Remove(carToDelete);
                await _context.SaveChangesAsync();
                return carToDelete;
            }
            return null;
        }
        public async Task<Car> GetById(Guid id) => await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Car> Update(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }
    }
}
