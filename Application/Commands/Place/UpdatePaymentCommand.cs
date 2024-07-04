namespace Application.Commands
{
    public class UpdatePlaceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public bool Is_Charge { get; set; }
        public int Voltage { get; set; } = 0;
        public UpdatePlaceCommand(Guid id, bool is_Charge, int voltage)
        {
            Id = id;
            Is_Charge = is_Charge;
            Voltage = voltage;
        }
    }
}
