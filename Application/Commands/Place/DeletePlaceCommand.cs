namespace Application.Commands
{
    public class DeletePlaceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeletePlaceCommand(Guid id)
        {
            Id = id;
        }
    }
}
