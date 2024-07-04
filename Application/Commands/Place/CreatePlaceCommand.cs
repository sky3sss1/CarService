namespace Application.Commands
{
    public class CreatePlaceCommand : IRequest<bool>
    {
        public bool Is_Charge { get; set; }
        public int Voltage { get; set; } = 0;
        public CreatePlaceCommand(bool is_Charge, int voltage)
        {
            Is_Charge = is_Charge;
            Voltage = voltage;
        }
    }
}
