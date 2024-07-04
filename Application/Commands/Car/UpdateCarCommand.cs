namespace Application.Commands
{
    public class UpdateCarCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string GovernmentNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int MinimalVoltage { get; set; } = 0;
        public UpdateCarCommand(Guid id, string governmentNumber, string model, int minimalVoltage)
        {
            Id = id;
            GovernmentNumber = governmentNumber;
            Model = model;
            MinimalVoltage = minimalVoltage;
        }
    }
}
