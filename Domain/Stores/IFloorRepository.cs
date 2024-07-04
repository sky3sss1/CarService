namespace Domain.Stores
{
    public interface IFloorRepository
    {
        Task<Floor> Add(Floor floor);
        Task<Floor> Delete(Floor floor);
        Task<Floor> Update(Floor floor);
        Task<Floor> GetById(Guid id);
        Task<IEnumerable<Floor>> GetAll();
    }
}
