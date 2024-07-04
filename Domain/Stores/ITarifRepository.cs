namespace Domain.Stores
{
    public interface ITarifRepository
    {
        Task<Tarif> Add(Tarif tarif);
        Task<Tarif> Delete(Tarif tarif);
        Task<Tarif> Update(Tarif tarif);
        Task<Tarif> GetById(Guid id);
        Task<IEnumerable<Tarif>> GetAll();
    }
}
