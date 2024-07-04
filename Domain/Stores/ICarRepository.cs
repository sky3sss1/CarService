namespace Domain.Stores
{
    public interface ICarRepository
    {
        Task<Car> Add(Car car);
        Task<Car> Delete(Car car);
        Task<Car> Update(Car car);
        Task<Car> GetById(Guid id);
        Task<IEnumerable<Car>> GetAll();
    }
}
