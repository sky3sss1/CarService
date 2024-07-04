namespace Application.Commands
{
    public class DeleteFloorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteFloorCommand(Guid id)
        {
            Id = id;
        }
    }
}
