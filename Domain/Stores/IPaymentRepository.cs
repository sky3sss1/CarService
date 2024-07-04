namespace Domain.Stores
{
    public interface IPaymentRepository
    {
        Task<Payment> Add(Payment payment);
        Task<Payment> Delete(Payment payment);
        Task<Payment> Update(Payment payment);
        Task<Payment> GetById(Guid id);
        Task<IEnumerable<Payment>> GetAll();
    }
}
