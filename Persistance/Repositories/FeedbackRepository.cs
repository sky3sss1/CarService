namespace Persistance.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async public Task<Feedback> Add(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<Feedback> Delete(Feedback feedback)
        {
            var feedbackToDelete = await _context.Feedbacks.FirstOrDefaultAsync(c => c.Id == feedback.Id);
            if (feedbackToDelete != null)
            {
                _context.Feedbacks.Remove(feedbackToDelete);
                await _context.SaveChangesAsync();
                return feedbackToDelete;
            }
            return null;
        }
        public async Task<Feedback> GetById(Guid id) => await _context.Feedbacks.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Feedback> Update(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }
        public async Task<IEnumerable<Feedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();
        }
    }
}
