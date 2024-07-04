namespace Application.Commands
{
    public class UpdateFloorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public int FloorNumber { get; set; }
        public UpdateFloorCommand(Guid id, int floorNumber)
        {
            Id = id;
            FloorNumber = floorNumber;
        }
    }
}
