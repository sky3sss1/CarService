namespace Application.Commands
{
    public class CreateCarCommand : IRequest<bool>
    {
        public string GovernmentNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int MinimalVoltage { get; set; } = 0;
        public CreateCarCommand(string governmentNumber, string model, int minimalVoltage)
        {
            GovernmentNumber = governmentNumber;
            Model = model;
            MinimalVoltage = minimalVoltage;
        }
    }
}
