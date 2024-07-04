namespace Application.Commands
{
    public class GetFloorByIdCommand : IRequest<Floor>
    {
        public Guid Id { get; set; }
        public GetFloorByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
