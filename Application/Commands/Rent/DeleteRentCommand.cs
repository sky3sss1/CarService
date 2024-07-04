namespace Application.Commands
{
    public class DeleteRentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteRentCommand(Guid id)
        {
            Id = id;
        }
    }
}