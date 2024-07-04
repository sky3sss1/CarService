namespace Application.Commands
{
    public class GetUserByIdCommand : IRequest<User>
    {
        public Guid Id { get; set; }

        public GetUserByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}