using System.Threading;

namespace Domain.Stores
{
    public interface IFeedbackRepository
    {
        Task<Feedback> Add(Feedback feedback);
        Task<Feedback> Delete(Feedback feedback);
        Task<Feedback> Update(Feedback feedback);
        Task<Feedback> GetById(Guid id);
        Task<IEnumerable<Feedback>> GetAll();
    }
}
