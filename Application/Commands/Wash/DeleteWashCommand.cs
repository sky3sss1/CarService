namespace Application.Commands
{
    public class DeleteWashCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteWashCommand(Guid id)
        {
            Id = id;
        }
    }
}
