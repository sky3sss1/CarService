namespace Application.Commands
{
    public class UpdateParkingCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid Floor_Id { get; set; }
        public Guid Place_Id { get; set; }
        public UpdateParkingCommand(Guid id, Guid floor_Id, Guid place_Id)
        {
            Id = id;
            Floor_Id = floor_Id;
            Place_Id = place_Id;
        }
    }
}
