namespace Application.Commands
{
    public class CreateFloorCommand : IRequest<bool>
    {
        public int FloorNumber { get; set; }
        public CreateFloorCommand(int floorNumber)
        {
            FloorNumber = floorNumber;
        }
    }
}
