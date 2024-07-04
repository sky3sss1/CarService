namespace Domain.Stores
{
    public interface IParkingRepository
    {
        Task<Parking> Add(Parking parking);
        Task<Parking> Delete(Parking parking);
        Task<Parking> Update(Parking parking);
        Task<Parking> GetById(Guid id);
        Task<IEnumerable<Parking>> GetAll();
    }
}
