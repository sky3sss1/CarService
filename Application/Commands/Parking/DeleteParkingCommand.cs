namespace Application.Commands
{
    public class DeleteParkingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteParkingCommand(Guid id)
        {
            Id = id;
        }
    }
}
