namespace Domain.Stores
{
    public interface IWashRepository
    {
        Task<Wash> Add(Wash wash);
        Task<Wash> Delete(Wash wash);
        Task<Wash> Update(Wash wash);
        Task<Wash> GetById(Guid id);
        Task<IEnumerable<Wash>> GetAll();
    }
}
