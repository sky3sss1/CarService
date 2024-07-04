namespace Persistance.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async public Task<Payment> Add(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> Delete(Payment payment)
        {
            var paymentToDelete = await _context.Payments.FirstOrDefaultAsync(c => c.Id == payment.Id);
            if (paymentToDelete != null)
            {
                _context.Payments.Remove(paymentToDelete);
                await _context.SaveChangesAsync();
                return paymentToDelete;
            }
            return null;
        }
        public async Task<Payment> GetById(Guid id) => await _context.Payments.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Payment> Update(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await _context.Payments.ToListAsync();
        }
    }
}
