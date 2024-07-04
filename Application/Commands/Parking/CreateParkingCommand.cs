namespace Application.Commands
{
    public class CreateParkingCommand : IRequest<bool>
    {
        public Guid Floor_Id { get; set; }
        public Guid Place_Id { get; set; }
        public CreateParkingCommand(Guid floor_Id, Guid place_Id)
        {
            Floor_Id = floor_Id;
            Place_Id = place_Id;
        }
    }
}
