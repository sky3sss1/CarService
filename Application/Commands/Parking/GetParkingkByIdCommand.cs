namespace Application.Commands
{
    public class GetParkingByIdCommand : IRequest<Parking>
    {
        public Guid Id { get; set; }
        public GetParkingByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
