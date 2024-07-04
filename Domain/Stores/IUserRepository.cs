namespace Domain.Stores
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<User> Delete(User user);
        Task<User> Update(User user);
        Task<User> GetById(Guid id);
        Task<IEnumerable<User>> GetAll();
    }
}
