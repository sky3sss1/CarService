namespace Domain.Stores
{
    public interface IPlaceRepository
    {
        Task<Place> Add(Place place);
        Task<Place> Delete(Place place);
        Task<Place> Update(Place place);
        Task<Place> GetById(Guid id);
        Task<IEnumerable<Place>> GetAll();
    }
}
