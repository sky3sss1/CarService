namespace Domain.Stores
{
    public interface IRentRepository
    {
        Task<Rent> Add(Rent rent);
        Task<Rent> Delete(Rent rent);
        Task<Rent> Update(Rent rent);
        Task<Rent> GetById(Guid id);
        Task<IEnumerable<Rent>> GetAll();
    }
}
